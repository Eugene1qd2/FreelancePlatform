   M S B A M L   `   `   `  ????L  HFreelancePlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:FreelancePlatformFreelancePlatform  5   	   c6clr-namespace:FreelancePlatform.Assets.MVVM.ViewModels(FreelancePlatform.Assets.MVVM.ViewModels  5   	   '    !FreelancePlatform.AcceptionWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:FreelancePlatform     5   	   Evm6clr-namespace:FreelancePlatform.Assets.MVVM.ViewModels     5   	     ? Title$  AcceptionWindow??5	   	   $	??340??6!   $	??630??6.    ? WindowStyle$
 None=?6:    ? 
ResizeMode$ NoResize=?6M    ? AllowsTransparency . 
??????  ? WindowStartupLocation$ CenterScreen=?6?   .??5
      ?? -   5        $??0q?5
      $??Center=?5      $??Center=?5      $	??630??5      $	??340??5       ?? CornerRadius$ 10??5      $??1??5       K? ZIndex$	 -10??5      ._?5   
   ? .+?5      ? $??0??6   
?????? $??25??6:   $	??Top=?6F    ? ColumnDefinitions 5      ?? 5      $??1* ?6'   ?? 5      $??37 ?6'   .+?5      ?? -   5        $??28(?5      ???#D9D9D9$??2??5      $??Center=?5      $??Center=?63   
?????? $??37??5      $??44??5       ?? TextAlignment$ Center=?5         OpacityHoverTheme#??[  5       ×6f   5!      ?? 5"      $??Center=?6   $??0,40,0,0q?64   .+?5$      ?? 
?????? ???#D9D9D9$??0,0,0,3q?6H   $	??440??5%      ._?5&      ?? .+?5'      ?? $??
Montserrat)?6$   $??26(?5(      $??Medium"?5)      ???#D9D9D9$	??440??5+      	 ?? Padding$
	 20,0q?5,      $'??!Код подтверждения??5-      ?? 5.      -   5        
 ??Name$
 	codeField??5:      $??
Montserrat)?5.   "   $??30(?5/      $??Medium"?50      ???#D9D9D9$	??440??52      $??60??53      
 ? Tag$' !Электронная почта??54       ?? 	MaxLength$ 50??55      
?????? $??0q?57      $??
30,10,30,0q?58      $??Bottom=?59      .??5:   -   5;      5<      5=      ?? 5>      -   5        $	??440??5>      $
??0,25q?5?      $??70??5@      $??Подтвердить??5A        WhiteButton#??[ 5B      $??36(?5C      $??Bottom=?5D       ? OverridesDefaultStyle . $??1??5F      ??5G      ?? *ConfirmMailCommand+6@   ?? 5H      -   5         ??Name$ mailText??5N      $??16(?5I      $??
Montserrat)?5J      $??Medium"?5K      ???#232931$??40??5M      ??5H      ?? *MailInfoText+ ?? Mode$ TwoWay=? ?? UpdateSourceTrigger$ PropertyChanged=?5N      5O      5P      ??5Q   
   ?? 5R       ?? 
StartPoint$	 0,0&?6"    ?? EndPoint$	 1,1&?63   .??5S      ?  ? Color$ #232931??6    ? Offset$ 0Q?6/   6<   ? 5T      $ 	#99232931??6   $ 1Q?61   6>   5U      ??5W   
   ?? 5X       ?? Triggers 5Y      :? 5Z       :? RoutedEvent$ Window.Loaded??6#   .[?5[      ?? .??5\      ?? .??5]   "   W?  g? Duration$ 0:0:0.7D?62    ?? TargetProperty$ Opacity?6E    W? From$ 0X?6i   	 W? To$ 1X?6r   t? 5^   "   $ 0:0:0.7D?65   $ Margin?6H    t? From$ 0,-1000,0,0X?6k   	 t? To$ 0,0,0,0X?6~    t? EasingFunction 5_   &   2  ,System.Windows.Media.Animation.QuadraticEase  5`   *   7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode$ EaseOut=?68   5b   #   5c      5d      5e      5g      5i      5k      