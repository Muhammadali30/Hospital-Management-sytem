using Aspose.Pdf.Annotations;
using MahApps.Metro.IconPacks;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        public static TextBox create_textbox(string? text = null,double ? width = null, bool? visibility = null, string? tag = null)
        {
            Style textBoxStyle = (Style)Application.Current.FindResource("textboxstyle");
            TextBox textbox = new TextBox();
            textbox.Text = text;
            textbox.Style = textBoxStyle;
            textbox.Tag = tag != null ? tag : "" ;
            textbox.Width = width.HasValue ? width.Value : double.NaN;
            textbox.IsEnabled = visibility.HasValue ? visibility.Value : true;
            if (visibility == false) { textbox.BorderBrush = new SolidColorBrush(Colors.Gray); }
            textbox.Margin = new Thickness(10);

            return textbox;
        }

        public static Button create_button(string icon = null,string? text = null, double? width = null,string? tooltip = null)
        {
            

            Style buttonstyle = (Style)Application.Current.FindResource("editbutton");
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
            button.Width = width.HasValue ? width.Value : double.NaN;
            //button.IsEnabled = visibility.HasValue ? visibility.Value : true;
            button.Background = System.Windows.Media.Brushes.Red;
            button.ToolTip = tooltip;
            //if (visibility == false) { button.BorderBrush = new SolidColorBrush(Colors.Gray); }
            button.Margin = new Thickness(10);
            return button;
        }

    }
}
