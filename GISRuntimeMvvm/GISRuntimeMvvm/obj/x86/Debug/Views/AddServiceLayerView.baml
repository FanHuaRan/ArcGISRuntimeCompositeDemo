   M S B A M L   `   `   `  ����  SimpleMvvm-Wpf.    (GISRuntimeMvvm.Views.AddServiceLayerView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  5   	   -   5          �Name$  addLayerWindow��5   	    � Title$ AddDataView��5   	   $	��200��6   $	��400��6*    � WindowStartupLocation$ CenterScreen=�5   	    � DataContext 5	   	   ��    Locator �� Source# [   �� Path$ AddServiceLayerViewModel�.��5
      � .+�5   
   �� $
��Left=�6   $��	25,23,0,0q�6/   $
��Wrap=�6B   $��图层名称：��6V   $	��Top=�6c   �� 5   
   $
��Left=�6   $��23��6-   $��	90,20,0,0q�69    �� TextWrapping$
 Wrap=�6L   $	��Top=�6}   $	��279��6�   ��6`   �� *DisplayName+6�   �� 5   
   $
��Left=�6   $��	25,67,0,0q�6/   $
��Wrap=�6B   $��服务地址：��6V   $	��Top=�6c   �� 5   
   $
��Left=�6   $��23��6-   $��	90,64,0,0q�69   $
 Wrap=�6L   $	��Top=�6|   $	��279��6�   ��6`   �� *
ServiceUrl+6�   �� 5   
   $��添加��6   $
��Left=�6   $��
90,125,0,0q�69   $	��Top=�6M   $��75��6e   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5         	EventName$ Click��6!   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6,   �� *AddLayerCommand+   CommandParameter 6P   ��  �� ElementName$ addLayerWindow��5      5      �� 5   
   $��取消��6   $
��Left=�6   $��264,125,0,0q�69   $	��Top=�6N   $��75��6f    5        5      $ Click��6!   .	 5        
 6,   �� *CloseCommand+ 6M   �� $ addLayerWindow��5      5      5      5      