using CarBuilder.Models;
using CarBuilder.Models.DTOs;

List<PaintColor> paintColors = new List<PaintColor>()
{
    new PaintColor()
    {
        Id = 1,
        Price = 200,
        Color = "Silver"
    },
    new PaintColor()
    {
        Id = 2,
        Price = 300,
        Color = "Midnight Blue"
    },
    new PaintColor()
    {
        Id = 3,
        Price = 400,
        Color = "Firebrick Red"
    },
    new PaintColor()
    {
        Id = 4,
        Price = 500,
        Color = "Spring Green"
    },
};

List<Interior> interiors = new List<Interior>()
{
    new Interior()
    {
        Id = 1,
        Price = 150,
        Material = "Beige Fabric"
    },
    new Interior()
    {
        Id = 2,
        Price = 175,
        Material = "Charcoal Fabric"
    },
    new Interior()
    {
        Id = 3,
        Price = 200,
        Material = "White Leather"
    },
    new Interior()
    {
        Id = 4,
        Price = 250,
        Material = "Black Leather"
    },

};

List<Technology> technologies = new List<Technology>()
{
    new Technology()
    {
        Id = 1,
        Price = 1000,
        Package = "Basic Package"
    },
    new Technology()
    {
        Id = 2,
        Price = 1500,
        Package = "Navigation Package"
    },
    new Technology()
    {
        Id = 3,
        Price = 2000,
        Package = "Visibility Package"
    },
    new Technology()
    {
        Id = 4,
        Price = 2500,
        Package = "Ultra Package"
    },

};

List<Wheels> wheels = new List<Wheels>()
{
    new Wheels()
    {
        Id = 1,
        Price = 500,
        Style = "17-inch Pair Radial"
    },
    new Wheels()
    {
        Id = 1,
        Price = 550,
        Style = "17-inch Pair Radial Black"
    },
    new Wheels()
    {
        Id = 1,
        Price = 600,
        Style = "18-inch Pair Spoke Silver"
    },
    new Wheels()
    {
        Id = 1,
        Price = 650,
        Style = "18-inch Pair Spoke Black"
    },

};

List<Order> orders = new List<Order>()
{
    new Order()
    {
        Id = 1,
        Timestamp = null,
        WheelId = 1,
        TechnologyId = 1,
        PaintId = 1,
        InteriorId = 1
    },
    new Order()
    {
        Id = 2,
        Timestamp = null,
        WheelId = 2,
        TechnologyId = 3,
        PaintId = 4,
        InteriorId = 2
    },
    new Order()
    {
        Id = 3,
        Timestamp = null,
        WheelId = 3,
        TechnologyId = 2,
        PaintId = 2,
        InteriorId = 4
    },
    new Order()
    {
        Id = 4,
        Timestamp = null,
        WheelId = 4,
        TechnologyId = 4,
        PaintId = 3,
        InteriorId = 3
    },
};

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.MapGet("/paintcolors", () =>
{
    return paintColors.Select(pc => new PaintColorDTO 
    {
        Id = pc.Id,
        Price = pc.Price,
        Color = pc.Color
    });
});

app.MapGet("/interiors", () =>
{
    List<InteriorDTO> interiorsList = interiors.Select(i => new InteriorDTO
    {
        Id = i.Id,
        Price = i.Price,
        Material = i.Material
    }).ToList();

    return interiorsList;
});
app.MapGet("/technologies", () =>
{
    return technologies.Select(tech => new TechnologyDTO 
    {
        Id = tech.Id,
        Price = tech.Price,
        Package = tech.Package
    });
});
app.MapGet("/wheels", () =>
{
    List<WheelsDTO> wheelsList = wheels.Select(wheel => new WheelsDTO 
    {
        Id = wheel.Id,
        Price = wheel.Price,
        Style = wheel.Style
    }).ToList();
    return wheelsList;
});
app.MapGet("/orders", () =>
{
    return orders.Select(order => new OrderDTO
    {
        Id = order.Id,
        Timestamp = order.Timestamp,
        WheelId = order.WheelId,
        TechnologyId = order.TechnologyId,
        PaintId = order.PaintId,
        InteriorId = order.InteriorId
    });
});


app.Run();


