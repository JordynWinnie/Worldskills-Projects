using KazanS5Backend;
using System.Drawing;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Session5Context>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/getWells", (Session5Context context) =>
{
    return context.Wells;
});

app.MapGet("/getLayers", (Session5Context context) =>
{
    return context.WellLayers;
});

app.MapGet("/getRockTypes", (Session5Context context) =>
{
    return context.RockTypes;
});

app.MapPost("/postWell", (Session5Context context, Well well) =>
{
    context.Wells.Add(well);
    context.SaveChanges();
});

app.MapPost("/postLayer", (Session5Context context, string wellName, WellLayer layer) =>
{
    var wellId = context.Wells.Where(x=>x.WellName == wellName).First();

    layer.WellId = wellId.Id;

    context.WellLayers.Add(layer);
    context.SaveChanges();
});

app.MapPut("/editWell", (Session5Context context, Well well) =>
{
    var wellToEdit = context.Wells.First(x=>x.Id == well.Id);

    wellToEdit.GasOilDepth = well.GasOilDepth;
    wellToEdit.WellName = well.WellName;
    wellToEdit.Capacity = well.Capacity;

    var layersToDelete = context.WellLayers.Where(x=>x.WellId == well.Id);

    context.WellLayers.RemoveRange(layersToDelete);
    context.SaveChanges();
});

app.Run();
