using KazanS3Backend;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Session3FinalContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/getPMTasks", (Session3FinalContext context) =>
{
    return context.Pmtasks
    .Select(
        x => new
        {
            x.Id,
            x.Asset.AssetName,
            x.Asset.AssetSn,
            taskName = x.Task.Name,
            scheduleType = x.PmscheduleType.Name,
            x.ScheduleDate,
            x.ScheduleKilometer,
            x.TaskDone
        }
        );
});

app.MapGet("/getAssets", (Session3FinalContext context) =>
{
    return context.Assets;
});

app.MapGet("/getTasks", (Session3FinalContext context) =>
{
    return context.Tasks;
});

app.MapPut("putAsset", (Session3FinalContext context, int taskid, bool status) =>
{
    Console.WriteLine(taskid);
    Console.WriteLine(status);
    context.Pmtasks.First(x => x.Id == taskid).TaskDone = status;
    context.SaveChanges();
});

app.MapGet("getScheduleModels", (Session3FinalContext context) =>
{
    return context.PmscheduleModels;
});

app.MapPost("postPmTask", (Session3FinalContext context, Pmtask pmtask) =>
{
    Console.WriteLine($"Post: {pmtask.ScheduleDate}");
    pmtask.TaskDone = false;
    context.Pmtasks.Add(pmtask);
    context.SaveChanges();
});

app.Run();

