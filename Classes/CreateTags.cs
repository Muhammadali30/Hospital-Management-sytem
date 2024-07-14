using MahApps.Metro.IconPacks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Final_Project.Classes
{
    static class CreateTags
    {
        public static StackPanel create_stackpanel(string? name = null, string? orientation = null, double? width = null)
        {
            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = (Orientation)Enum.Parse(typeof(Orientation), orientation ?? "Vertical", true);
            stackPanel.Name = name;
            stackPanel.Width = width.HasValue ? width.Value : Double.NaN;
            return stackPanel;
        }
        public static WrapPanel create_wrappanel(string? orientation = null, double? width = null)
        {
            WrapPanel wrapPanel = new WrapPanel();
            wrapPanel.Width = width ?? Double.NaN;
            wrapPanel.Orientation = (Orientation)Enum.Parse(typeof(Orientation), orientation ?? "Vertical", true);
            return wrapPanel;
        }
        public static TextBlock create_textblock(string text, double? size = null)
        {
            TextBlock textblock = new TextBlock();
            textblock.Text = text;
            textblock.Margin = new Thickness(10);
            textblock.FontWeight = FontWeights.SemiBold;
            textblock.FontSize = size.HasValue ? size.Value : 16;
            return textblock;
        }
        public static TextBox create_textbox(string? text = null, double? width = null, bool? visibility = null, string? tag = null)
        {
            Style textBoxStyle = (Style)Application.Current.FindResource("textboxstyle");
            TextBox textbox = new TextBox();
            textbox.Text = text;
            textbox.Style = textBoxStyle;
            textbox.Tag = tag != null ? tag : "";
            textbox.Width = width.HasValue ? width.Value : double.NaN;
            textbox.IsEnabled = visibility.HasValue ? visibility.Value : true;
            if (visibility == false) { textbox.BorderBrush = new SolidColorBrush(Colors.Gray); }
            textbox.Margin = new Thickness(10);

            return textbox;
        }

        public static Button create_button(string icon = null, string? text = null, double? width = null, string? tooltip = null, string? colorname = null)
        {
            Style buttonstyle = (Style)Application.Current.FindResource("button");
            Button button = new Button();
            if (icon != null)
            {
                PackIconMaterialKind packIconMaterialKind = (PackIconMaterialKind)Enum.Parse(typeof(PackIconMaterialKind), icon);
                button.Content = new PackIconMaterial { Kind = packIconMaterialKind };
            }
            else
            {
                button.Content = text;
            }
            button.Style = buttonstyle;
            button.Margin = new Thickness(12.5);
            button.Width = width.HasValue ? width.Value : double.NaN;
            System.Windows.Media.Brush brush = (System.Windows.Media.Brush)new BrushConverter().ConvertFromString(colorname);
            button.Background = brush;
            button.ToolTip = tooltip;
            button.HorizontalAlignment = HorizontalAlignment.Left;
            return button;
        }

        public static DatePicker create_datepicker(double? width = null)
        {
            Style datepickerStyle = (Style)Application.Current.FindResource("datepickerstyle");
            DatePicker datePicker = new DatePicker();
            datePicker.Width = width ?? double.NaN;
            datePicker.Margin = new Thickness(5);
            //datePicker.Style = datepickerStyle;
            return datePicker;
        }

        public static Border create_border(double width)
        {
            Border border = new Border
            {
                Width = width,
                CornerRadius = new CornerRadius(3),
                Margin = new Thickness(11),
                Background = System.Windows.Media.Brushes.White,
                BorderBrush = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("Black")),
                BorderThickness = new Thickness(1),
            };
            return border;
        }

        public static ComboBox create_combobox(double width)
        {
            ComboBox comboBoxtemplate = new ComboBox
            {
                Name = "comboBoxtemplate",
                //Background = System.Drawing.Brushes.White,
                //BorderBrush = Brushes.White,
                BorderThickness = new Thickness(0),
                Width = width,
                IsEditable = true,
                IsTextSearchEnabled = true,
                StaysOpenOnEdit = true,
                Margin = new Thickness(2),
                FontSize = 16
            };
            return comboBoxtemplate;
        }







        public static void tag_focus(object sender, EventArgs e)
        {
            if (sender is Control control)
            {
                if (control.FontWeight == FontWeights.Normal)
                {
                    control.Width = 300;
                    control.FontSize = 30;
                    control.FontWeight = FontWeights.SemiBold;
                }
                else
                {
                    control.Width = 230;
                    control.FontSize = 16;
                    control.FontWeight = FontWeights.Normal;
                }
            }
        }
        public static bool IsTextAllowed(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
        public static void IsTextAllowedPasting(DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string text = (string)e.DataObject.GetData(typeof(string));
                if (!IsTextAllowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }
    }
}
