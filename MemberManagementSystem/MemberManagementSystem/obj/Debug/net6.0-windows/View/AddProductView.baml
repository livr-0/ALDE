   M S B A M L   `   `   `  ????Q  MMemberManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:MemberManagementSystem.ViewMemberManagementSystem.View  5      0    *MemberManagementSystem.View.AddProductView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:MemberManagementSystem.View     5      .??5	      ?   ? RowDefinitions  5
   
   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $??10 ?6   ?? 5      $
??auto ?6   ?? 5      $??10 ?6   ?? 5      $
??auto ?6   ?? 5      $??10 ?6   ?? 5      $
??auto ?6   ?? 5      $??10 ?6   ?? 5      $
??auto ?6   ?? 5      $??10 ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6    ? ColumnDefinitions 5   
   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   .+?5   
   ?  5      ?? 5      $
??auto ?6#   ?? 5       $
??auto ?6#   .+?5"      ?? $??0??6   $??0??6!   $??Naviagtion Menu??62   ?? 5#      $??0??6   $??1??6"   $
??Home??62   ??6A   ?? *
HomePage+5$      ?? 5%   
   $??1??6   $??Add A Product??6   ? 5&   
   $??3??6    5'      ?? 5(      $	??150 ?6#   ?? 5)      $
??auto ?6#   ?? 5*      $??5 ?6#   ?? 5+      $
??auto ?6#   .+?5-      ?? $??0??6   $??0??6!   $??
Enter Name??62   ?? 5.      $??1??6   $	??135??6&   ??62   ?? *	NameColor+ ?? NotifyOnTargetUpdated$
 True?? ?? NotifyOnSourceUpdated$
 True?? ?? UpdateSourceTrigger$ PropertyChanged=???6?   ?? *Name+$ PropertyChanged=??? 5/      $??3??6   
???  ????6(   ?? *	NameError+$
 True??$
 True??$ PropertyChanged=?6?   50      ? 51   
   $??5??6    52      ?? 53      $	??150 ?6#   ?? 54      $
??auto ?6#   ?? 55      $??5 ?6#   ?? 56      $
??auto ?6#   .+?58      ?? $??0??6   $??0??6!   $??Enter Description??62   ?? 59      $??1??6   $	??135??6&   ??62   ?? *	DescColor+$
 True??$
 True??$ PropertyChanged=???6?   ?? *Description+$ PropertyChanged=??? 5:      $??3??6   
???  ????6(   ?? *	DescError+$
 True??$
 True??$ PropertyChanged=?6?   5;      ? 5<   
   $??7??6    5=      ?? 5>      $	??150 ?6#   ?? 5?      $
??auto ?6#   ?? 5@      $??5 ?6#   ?? 5A      $
??auto ?6#   .+?5C      ?? $??0??6   $??0??6!   $??Enter Price??62   ?? 5D      -   5        $??1??5D      $	??135??6&   ??62   ?? *
PriceColor+$ PropertyChanged=???6?   ?? *Price+$ PropertyChanged=??? 5E      $??3??6   
???  ????6(   ?? *
PriceError+$
 True??$
 True??$ PropertyChanged=?6?   5F      ? 5G   
   $??9??6    5H      ?? 5I      $	??150 ?6#   ?? 5J      $
??auto ?6#   ?? 5K      $??5 ?6#   ?? 5L      $
??auto ?6#   .+?5N      ?? $??0??6   $??0??6!   $??Enter Quantity??62   ?? 5O      -   5        $??1??5O      $	??135??6&   ??62   ?? *QuantityColor+$
 True??$
 True??$ PropertyChanged=???6?   ?? *
Quantity+$ PropertyChanged=??? 5P      $??3??6   
???  ????6(   ?? *QuantityError+$
 True??$
 True??$ PropertyChanged=?6?   5Q      ?? 5R   
   $??11??6   $??Submit??6   $	??290??60   $
??Left=?6<   ??6W   ?? *SubmitProduct+?? 5S   
   $??12??6   ??6"   ?? *	SubmitMsg+$
 True??$
 True??$ PropertyChanged=???6?   ?? *SubmitMsgColor+$
 True??$
 True??$ PropertyChanged=?5T      5U      