using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Final_Project.Classes
{
   static class CreateTags
    {
        public static StackPanel create_stackpanel(string? name = null, string? orientation = null, double? width = null) {
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
        public static TextBlock create_textblock(string text,double ? size =null)
        {
            TextBlock textblock = new TextBlock();
            textblock.Text = text;
            textblock.Margin = new Thickness(10);
            textblock.FontWeight = FontWeights.SemiBold;
            textblock.FontSize = size.HasValue ? size.Value : 16;
            return textblock;
        }
        public static TextBox create_textbox(string text,double ? width = null, bool? visibility = null)
        {
            Style textBoxStyle = (Style)Application.Current.FindResource("textboxstyle");
            TextBox textbox = new TextBox();
            textbox.Text = text;
            textbox.Style = textBoxStyle;
            textbox.Width = width.HasValue ? width.Value : double.NaN;
            textbox.IsEnabled = visibility.HasValue ? visibility.Value : true;
            if (visibility == false) { textbox.BorderBrush = new SolidColorBrush(Colors.Gray); }
            textbox.Margin = new Thickness(10);

            return textbox;
        }
    }
}
