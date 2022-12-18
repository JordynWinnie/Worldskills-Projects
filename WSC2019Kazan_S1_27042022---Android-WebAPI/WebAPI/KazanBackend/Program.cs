using KazanBackend;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Session1Context>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/getPhotos", (Session1Context context, int id) =>
{
    return context.AssetPhotos.Where(x=>x.AssetId == id);
});

app.MapDelete("/deletePhoto", (Session1Context context, int id) =>
{
    var currentPhotos = context.AssetPhotos.Where(x => x.AssetId == id);
    context.AssetPhotos.RemoveRange(currentPhotos);
    context.SaveChanges();
});

app.MapPost("/addphoto", (Session1Context context, KotlinPhoto photo) =>
{
    var base64String = Convert.FromBase64String(photo.AssetPhoto1);

    var newPhoto = new AssetPhoto
    {
        AssetId = photo.AssetId,
        AssetPhoto1 = base64String,
    };

    context.AssetPhotos.Add(newPhoto);
    context.SaveChanges();
});

app.MapPut("/updateAsset", (Session1Context context, KotlinAssetClass asset, int id) =>
{
    var editAsset = context.Assets.First(x=>x.Id == id);
    editAsset.WarrantyDate = asset.warrantyDate;
    editAsset.AssetSn = asset.assetSn;
    editAsset.AssetName = asset.assetName;
    editAsset.Description = asset.description;

    var assetGroupId = context.AssetGroups.Where(
    x => x.Name.Equals(asset.assetGroupName)).First();

    var departmentLocationId = context.DepartmentLocations.Where(
        x => x.Department.Name.Equals(asset.departmentName) && x.Location.Name.Equals(asset.locationName)).First();

    editAsset.DepartmentLocationId = departmentLocationId.Id;
    editAsset.AssetGroupId = assetGroupId.Id;
    context.SaveChanges();
});

app.MapGet("/departments", (Session1Context context) =>
{
    return context.Departments;
});

app.MapGet("/departmentlocations", (Session1Context context) =>
{
    return context.DepartmentLocations.Where(x => x.EndDate == null)
    .Select(x => new { x.Id, department_name = x.Department.Name, location_name = x.Location.Name });
});

app.MapGet("/accountableparties", (Session1Context context) =>
{
    return context.Employees;
});


app.MapGet("/locations", (Session1Context context) =>
{
    return context.Locations;
});


app.MapGet("/assetgroups", (Session1Context context) =>
{
    return context.AssetGroups;
});

app.MapGet("/assets", (Session1Context context, int? id) =>
{
    var data = context.Assets.Select(x => new
    {
        x.Id,
        x.AssetSn,
        x.AssetName,
        departmentName = x.DepartmentLocation.Department.Name,
        locationName = x.DepartmentLocation.Location.Name,
        x.WarrantyDate,
        assetGroupName = x.AssetGroup.Name,
        x.Description,
        x.AssetPhotos.FirstOrDefault().AssetPhoto1,
        accountableParty = $"{x.Employee.FirstName} {x.Employee.LastName}"
    });

    if (id.HasValue) data = data.Where(x => x.Id == id);
    return data;
});

app.MapPost("/postasset", (Session1Context context, KotlinAssetClass asset) => 
{
    var newAsset = new Asset
    {
        AssetSn = asset.assetSn,
        AssetName = asset.assetName,
        WarrantyDate = asset.warrantyDate,
        Description = asset.description
    };

    var accountableParty = context.Employees.Where(
        x=> asset.accountableParty.Contains(x.FirstName) && asset.accountableParty.Contains(x.LastName))
    .First();

    var assetGroupId = context.AssetGroups.Where(
        x => x.Name.Equals(asset.assetGroupName)).First();

    var departmentLocationId = context.DepartmentLocations.Where(
        x => x.Department.Name.Equals(asset.departmentName) && x.Location.Name.Equals(asset.locationName)).First();

    newAsset.EmployeeId = accountableParty.Id;
    newAsset.DepartmentLocationId = departmentLocationId.Id;
    newAsset.AssetGroupId = assetGroupId.Id;
    
    var newAssetPosted = context.Assets.Add(newAsset);
    context.SaveChanges();
    Console.WriteLine(newAssetPosted.Entity.Id.ToString());
    return newAssetPosted.Entity.Id.ToString();
});

app.MapGet("/assetTransferLogs", (Session1Context context) =>
{
    var transferLogs = context.AssetTransferLogs.Select(x => new
    {
        x.Id,
        x.AssetId,
        x.TransferDate,
        x.FromAssetSn,
        x.ToAssetSn,
        x.FromDepartmentLocationId,
        x.ToDepartmentLocationId,
        fromDepartment = x.FromDepartmentLocation.Department.Name,
        toDepartment = x.ToDepartmentLocation.Department.Name,
        fromLocation = x.FromDepartmentLocation.Location.Name,
        toLocation = x.ToDepartmentLocation.Location.Name
    });

    return transferLogs;
});

app.MapPost("/addAssetTransfer", (Session1Context context, KotlinAssetTransferClass asset) =>
{
    var toDepartmentLocationId = context.DepartmentLocations
        .Where(x=>x.Location.Name == asset.toLocation && x.Department.Name == asset.toDepartment)
        .First().Id;

    var fromDepartmentLocationId = context.DepartmentLocations
        .Where(x=>x.Location.Name == asset.fromLocation && x.Department.Name == asset.fromDepartment)
        .First().Id;

    var newAssetTransferLog = new AssetTransferLog()
    {
        AssetId = asset.assetId,
        TransferDate = asset.transferDate,
        FromAssetSn = asset.fromAssetSn,
        ToAssetSn = asset.toAssetSn,
        FromDepartmentLocationId = fromDepartmentLocationId,
        ToDepartmentLocationId = toDepartmentLocationId,
    };

    var assetToChange = context.Assets.First(x => x.Id == asset.assetId);
    assetToChange.AssetSn = asset.toAssetSn;
    assetToChange.DepartmentLocationId = toDepartmentLocationId;

    context.AssetTransferLogs.Add(newAssetTransferLog);
    context.SaveChanges();
});

app.Run();