   M S B A M L   `   `   `  ????Q  MMemberManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:MemberManagementSystem.ViewMemberManagementSystem.View  5      +    %MemberManagementSystem.View.LoginView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:MemberManagementSystem.View     5      .??5	      ?   ? RowDefinitions  5
   
   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $??10 ?6   ?? 5      $
??auto ?6   ?? 5      $??10 ?6   ?? 5      $
??auto ?6   ?? 5      $??10 ?6   ?? 5      $
??auto ?6    ? ColumnDefinitions 5   
   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   .+?5   
   ?  5      ?? 5      $
??auto ?6#   ?? 5      $
??auto ?6#   5      ?? 5   
   $??1??6   $??Log In??6   ? 5   
   $??3??6    5       ?? 5!      $	??150 ?6#   ?? 5"      $
??auto ?6#   .+?5$      ?? $??0??6   $??0??6!   $??Enter Username??62   ?? 5%      $??1??6   $	??135??6&   ??62   ?? *
Username+ ?? UpdateSourceTrigger$ PropertyChanged=?5&      ? 5'   
   $??5??6    5(      ?? 5)      $	??150 ?6#   ?? 5*      $
??auto ?6#   .+?5,      ?? $??0??6   $??0??6!   $??Enter Password??62   ?? 5-      $??1??6   $	??135??6&   ??62   ?? *
Password+$ PropertyChanged=?5.      ?? 5/   
   $??9??6   $??Login??6   ??6.   ?? *AttemptLogin+52      53      