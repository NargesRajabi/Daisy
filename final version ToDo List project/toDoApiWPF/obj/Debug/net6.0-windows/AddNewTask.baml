   M S B A M L   `   `   `  ????E  AtoDoApiWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:toDoApiWPF
toDoApiWPF  5   	       toDoApiWPF.AddNewTask   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:toDoApiWPF     5   	     ? Title$  
AddNewTask??5   	   $	??450??6   $	??800??6)   .??5	      ? 
????İ?.+?5
   
   ?? -   5         ??Name$
 Home??5
      $
??Home??6   $
??Left=?6.   $??	33,41,0,0q?6I   $	??Top=?6\   $??35??6t   $	??101??6?   
???????6?   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid??5      $??178,41,103,217q?6T   
????İ?6l   ?? 5   
   -   5         ??Name$ activity??5      $
??Left=?6$   $??240,276,0,0q?6?    ?? TextWrapping$
 Wrap=?6T   $	??Top=?6h   $	??173??6?   $??86??6?   
???????6?   ?? 5   
   -   5        $ dateTm??5      $
??Left=?6"   $??240,382,0,0q?6=   $
 Wrap=?6R   $	??Top=?6f   $	??173??6~   $??23??6?   
???????6?   ?? 5   
   -   5        $ id??5      $
??Left=?6   $??240,236,0,0q?69   $
 Wrap=?6N   $	??Top=?6b   $	??173??6z   
???????6?   ?? 5   
   $	??ID:??6   $
??Left=?6   $??
15,236,0,0q?69   $	??Top=?6M    J? RenderTransformOrigin$ 0.395,0.033&?6e   $??91??6?   ?? 5   
   $??	Activity:??6   $
??Left=?6$   $??
10,276,0,0q?6?   $	??Top=?6S   $ 0.329,0.564&?6k   $??75??6?   $??30??6?   $??14(?6?   ?? 5   
   $#??Enter Date (yyyy/mm/dd hh:mm)??6   $
??Left=?68   $??	0,382,0,0q?6S   $	??Top=?6f   $ -0.062,0.607&?6~   $??14(?6?   ?? 5   
   -   5        $ search??5      $??Search??6!   $
??Left=?62   $??488,235,0,0q?6M   $	??Top=?6b   $??27??6z   $??60??6?   
???????6?   ?? 5   
   -   5        $ Update??5      $??Update??6!   $
??Left=?62   $??488,288,0,0q?6M   $	??Top=?6b   $??27??6z   $??60??6?   
???????6?   ?? 5   
   -   5        $ Insert??5      $??Insert??6!   $
??Left=?62   $??488,336,0,0q?6M   $	??Top=?6b   $??26??6z   $??60??6?   
???????6?   ?? 5   
   -	   5         ??Name$ ServerStatus1??5      $??ServerStatus??6'   $
??Left=?6>   $??618,235,0,0q?6Y   $	??Top=?6n   $??27??6?   $	??105??6?   ?? 5   
   -
   5        $ ServerStatus2??5      $??ServerStatus??6'   $
??Left=?6>   $??618,372,0,0q?6Y   $	??Top=?6n   $ 0.308,0.269&?6?   $??27??6?   $	??105??6?   ?? 5   
   -   5        $ ServerStatus3??5      $??ServerStatus??6'   $
??Left=?6>   $??618,288,0,0q?6Y   $	??Top=?6n   $ 0.139,-0.053&?6?   $??27??6?   $	??105??6?   ?? 5   
   -   5        $ ServerStatus4??5      $??ServerStatus??6'   $
??Left=?6>   $??618,331,0,0q?6Y   $	??Top=?6n   $??27??6?   $	??105??6?   ?? 5   
   -   5        $ viewData??5      $??	View Data??6#   $
??Left=?67   $??
33,110,0,0q?6R   $	??Top=?6f   $??36??6~   $	??101??6?   
???????6?   ?? 5   
   -   5         ??Name$ Delete??5      $
??Done??6#   $
??Left=?62   $??488,382,0,0q?6M   $	??Top=?6b   $??17??6z   $??83??6?   
???????6?   5      5      