   M S B A M L   `   `   `  ����B  >SmartCA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:SmartCA.Presentation.ViewModelsSmartCA.Presentation.ViewModels  5      G(clr-namespace:SmartCA.Presentation.ViewsSmartCA.Presentation.Views  5	      ,    &SmartCA.Presentation.Views.CompanyView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2006     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      Y UXceed.Wpf.DataGrid, Version=2.9.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f45xcdg*http://schemas.xceed.com/wpf/xaml/datagrid  5      =	viewModel-clr-namespace:SmartCA.Presentation.ViewModels  5      ;presentation(clr-namespace:SmartCA.Presentation.Views  5	      -   5          �Name$  companiesWindow��5       � Title$ 	Companies��5
      $	��800��5      $	��600��6      FormBackgroundBrush#��[  6   .��5      �  � RowDefinitions 5      �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6    � ColumnDefinitions 5      �� 5      $��1* �6   �� 5      $��2* �6   .+�5      ��   headerLabelStyle#��[ 6	   $��10q�63   $��0��6?   $��0��6L   .��6\   	Companies6g   �� 5      #��[ 6	   $��
0,10,10,10q�63   $��0��6G   $��1��6T   .��6d   Selected Company6v   �� 5      $��
10,0,10,10q�6   $��1��6   $��0��6,   $ �� IsSynchronizedWithCurrentItem$
 TrueY�5       �� DisplayMemberPath$
 Name��5!       �� SelectedItem 5      ��  �� Path$ CurrentCompany���5       �� $ 	Companies�5!      �� 5#      
���   �$��1q�6   $��	0,0,10,10q�62   $��1��6E   $��1��6R   ._�5$      �� .��5%      �  5'      �� 5(      $
��Auto �6   �� 5)      $
��Auto �6   �� 5*      $
��Auto �6   �� 5+      $
��Auto �6   �� 5,      $
��Auto �6   �� 5-      $
��Auto �6   �� 5.      $
��Auto �6   �� 5/      $
��Auto �6    52      �� 53      $
��Auto �6   �� 54      $
��Auto �6   .+�57      �� $��0��6   $��0��6   $��Name:��6)     baseLabelStyle#��[ 58      �� 59      $��0��6   $��1��6   ��6+   �� $ CurrentCompany.Name��� 5;      $��1��6   $��0��6   $��Abbreviation:��6)   #��[ 5<      �� 5=      $��1��6   $��1��6   ��6+   �� $! CurrentCompany.Abbreviation��� 5?      $��2��6   $��0��6   $��Address Info:��6)   #��[ 5@      *   $SmartCA.Presentation.Views.Addresses  5A      $��2��6   $��1��6*    � DataContext 6:   �� $ 	Addresses��� 5C      $��3��6   $��0��6   $��Headquarters Address:��6)   #��[ 5D      �� 5E      $��3��6   $��1��6    5F      �� $ HeadquartersAddress���5G      �� $ 	Addresses�5H      �� 5J      $��4��6   $��0��6   $��Phone Number:��6)   #��[ 5K      �� 5L      $��4��6   $��1��6   ��5M      �� $  CurrentCompany.PhoneNumber��� 5O      $��5��6   $��0��6   $��Fax Number:��6)   #��[ 5P      �� 5Q      $��5��6   $��1��6   ��5R      �� $ CurrentCompany.FaxNumber��� 5T      $��6��6   $��0��6   $
��URL:��6)   #��[ 5U      �� 5V      $��6��6   $��1��6   ��5W      �� $ CurrentCompany.Url��� 5Y      $��7��6   $��0��6   $��Remarks:��6)   #��[ 5Z      �� 5[      $��7��6   $��1��6   	 �� TextWrapping$
	 Wrap=�5]      ��5\      �� $ CurrentCompany.Remarks�5]      5^      5_      5`      �� 5b      $��Right=�6
   $��
10,0,10,10q�6&   $��2��6:   $��0��6G   ��6W   �� $ 
NewCommand�.��6{   New6�   �� 5c      $��Right=�6   
 �� Orientation$
 
Horizontal=�6*   $��2��6C   $��1��6P   .+�5d      �� $��2��6   $��
10,0,10,10q�6   $��0��6-   ��6=   �� $ SaveCommand�.��6b   Save6h   �� 5e      $��2��6   $��	0,0,10,10q�6   $��0��6,   ��6<   �� $ CancelCommand�.��6c   Cancel6k   5f      5h      5j      