   M S B A M L   `   `   `  ����  SimpleMvvm-Wpf2    ,GISRuntimeMvvm.Views.AddLocalNormalLayerView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  5   	   -   5          �Name$  addLayerWindow��5   .    � Title$ AddLocalNormalLayerView��5   	   $	��200��6)   $	��350��66    � WindowStartupLocation$ CenterScreen=�5   	    � DataContext 5   	   ��    Locator �� Source# [   �� Path$" AddLocalNormalLayerViewModel�.��5	      � .+�5
   
   �� $
��Left=�6   $��	25,23,0,0q�6/   $
��Wrap=�6B   $��图层名称：��6V   $	��Top=�6c   �� 5   
   $
��Left=�6   $��23��6-   $��	90,20,0,0q�69    �� TextWrapping$
 Wrap=�6L   $	��Top=�6}   $	��176��6�   ��6`   �� *DisplayName+6�   �� 5   
   $
��Left=�6   $��	25,67,0,0q�6/   $
��Wrap=�6B   $��文件路径：��6V   $	��Top=�6c   �� 5   
   $
��Left=�6   $��23��6-   $��	90,64,0,0q�69   $
 Wrap=�6L   $	��Top=�6z   $	��176��6�   ��6`   �� *
FilePath+6�   �� 5   
   $��添加��6   $
��Left=�6   $��
25,125,0,0q�69   $	��Top=�6M   $��75��6e   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5         	EventName$ Click��6!   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6,   �� *AddLayerCommand+   CommandParameter 6P   ��  �� ElementName$ addLayerWindow��5      5      �� 5   
   $��取消��6   $
��Left=�6   $��207,125,0,0q�69   $	��Top=�6N   $��75��6f    5        5      $ Click��6!   .	 5        
 6,   �� *CloseCommand+ 6M   �� $ addLayerWindow��5      5      �� 5   
   $��选择��6   $
��Left=�6   $��
275,67,0,0q�69   $	��Top=�6M   $��57��6e   $��20��6p   ��6|   �� *ChooseFileCommand+5      5      