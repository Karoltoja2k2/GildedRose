// See https://aka.ms/new-console-template for more information

using GildedRoseKata;
using GildedRoseScheduler;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder(args);

var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

builder.ConfigureServices((context, services) =>
{
    IList<Item> items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
                // this conjured item does not work properly yet
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

    var settings = context.Configuration.GetSection(nameof(SchedulerSettings));
    services.Configure<SchedulerSettings>(settings);

    services.AddSingleton<IList<Item>>(items);
    services.AddSingleton<GildedRose>();
    services.AddHostedService<BackgroundScheduler>();
});

await builder.Build().RunAsync();
