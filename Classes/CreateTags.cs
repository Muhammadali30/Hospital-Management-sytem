using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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
        public static TextBlock create_textblock(string text)
        {
            TextBlock textblock = new TextBlock();
            textblock.Text = text;
            return textblock;
        }
        public static TextBox create_textbox(string text)
        {
            Style textBoxStyle = (Style)Application.Current.FindResource("textboxstyle");
            TextBox textbox = new TextBox();
            textbox.Text = text;
            return textbox;
        }
    }
}
