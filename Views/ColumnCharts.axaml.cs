using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using System.Collections.Generic;
using System.Linq;

namespace RTC.Views
{
    public class ColumnChart : Control
    {
        public static readonly StyledProperty<IEnumerable<ChartItem>> ItemsProperty =
            AvaloniaProperty.Register<ColumnChart, IEnumerable<ChartItem>>(nameof(Items));

        public static readonly StyledProperty<double> MaxColumnHeightProperty =
            AvaloniaProperty.Register<ColumnChart, double>(nameof(MaxColumnHeight), 200);

        public IEnumerable<ChartItem> Items
        {
            get => GetValue(ItemsProperty);
            set => SetValue(ItemsProperty, value);
        }

        public double MaxColumnHeight
        {
            get => GetValue(MaxColumnHeightProperty);
            set => SetValue(MaxColumnHeightProperty, value);
        }

        static ColumnChart()
        {
            AffectsRender<ColumnChart>(ItemsProperty, MaxColumnHeightProperty);
        }

        public override void Render(DrawingContext context)
        {
            base.Render(context);

            if (Items == null) return;

            var bounds = Bounds;
            var padding = 10;
            var availableWidth = bounds.Width - padding * 2;
            var availableHeight = bounds.Height - padding * 2;

            var itemsList = Items.ToList();
            if (itemsList.Count == 0) return;

            // Находим максимальное значение для масштабирования
            var maxValue = itemsList.Max(item => item.Value);

            if (maxValue == 0) return;

            var columnWidth = (availableWidth - (itemsList.Count - 1) * 5) / itemsList.Count;
            var scale = MaxColumnHeight / maxValue;

            for (int i = 0; i < itemsList.Count; i++)
            {
                var item = itemsList[i];
                var columnHeight = item.Value * scale;
                
                var x = padding + i * (columnWidth + 5);
                var y = availableHeight + padding - columnHeight;

                // Рисуем столбец
                var brush = new SolidColorBrush(item.Color);
                var rect = new Rect(x, y, columnWidth, columnHeight);
                context.FillRectangle(brush, rect);

                // Рисуем обводку
                context.DrawRectangle(new Pen(Brushes.Black), rect);
            }
        }
    }
}