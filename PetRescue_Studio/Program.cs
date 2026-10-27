using System;
using System.Collections.Generic;
using System.Linq;

namespace PetRescue_Studio
{
    // Описание одного
    public class Item
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Value { get; set; }

        // Удельная ценность (ценность за единицу веса) для жадного алгоритма
        public double Ratio => Value / Weight;
    }

    public class Program
    {
        public static void Main()
        {
            // Набор лута для нашей авантюры
            var items = new List<Item>
            {
                new Item { Name = "Эликсир Бессонницы", Weight = 2.0, Value = 40.0 },
                new Item { Name = "Жидкая Удача", Weight = 3.5, Value = 70.0 },
                new Item { Name = "Экстракт Ностальгии", Weight = 1.0, Value = 30.0 },
                new Item { Name = "Слеза Единорога", Weight = 4.0, Value = 80.0 },
                new Item { Name = "Настойка Забывчивости", Weight = 2.5, Value = 50.0 }
            };

            double maxCapacity = 7.0; // Влезающий в рюкзак вес

            Console.WriteLine("=== ОГРАБЛЕНИЕ ЛАВКИ АЛХИМИКА ===");
            Console.WriteLine($"Вместимость рюкзака: {maxCapacity} кг\n");

            RunKnapsackGreedy(items, maxCapacity);
        }

        private static void RunKnapsackGreedy(List<Item> items, double capacity)
        {
            // Сортируем предметы по убыванию удельной ценности (самые выгодные — в начале)
            var sortedItems = items.OrderByDescending(i => i.Ratio).ToList();

            double currentWeight = 0;
            double totalValue = 0;
            var takenItems = new List<string>();

            foreach (var item in sortedItems)
            {
                if (currentWeight + item.Weight <= capacity)
                {
                    currentWeight += item.Weight;
                    totalValue += item.Value;
                    takenItems.Add($"{item.Name} (вес: {item.Weight}, ценность: {item.Value})");
                }
            }

            // Выводим результаты
            Console.WriteLine("Успешно утащили в рюкзаке:");
            foreach (var element in takenItems)
            {
                Console.WriteLine($" - {element}");
            }

            Console.WriteLine($"\nИтоговый вес: {currentWeight} / {capacity} кг");
            Console.WriteLine($"Общая ценность добычи: {totalValue} золотых монеток.");
        }

    }
}
