   M S B A M L   `   `   `  ����D  @WPFBattle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:WPFBattle	WPFBattle  5   	       WPFBattle.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:WPFBattle     5   	     � Title$  
MainWindow��5   	   $	��450��6   $
��1024��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      -   5         ��Name$ simRow��5      $	��260 �6,   �� 5      -   5        $ 
consoleRow��5      $��* �60   .+�5   
   �� -   5         ��Name$ 
background��5      $��stretch=�6$   $
��auto��6B   $��stretch=�6P   $
��auto��6l   $��assets/back4.jpg��6y   $��UniformToFill=�6�   $��
0,-219,0,0q�6�   �� 5   
   -   5         ��Name$
 test��5      $��1��6    $��stretch=�6-   $
��auto��6K   $��0,15,0,0q�6Y    �� TextWrapping$
 Wrap=�6l   $�� ��6�   $��stretch=�6�   $
��auto��6�   
�������$��Courier New)�6�   $
��Bold"�6�    �� TextAlignment$ Center=�6�   $��0,0,0,-2q�6  .��6  ��5      �� 5       �� ImageSource$ assets/text-back.png��6   .��5   "   5        WPFBattle.CharacterImage  5   
   -   5          Name$ p1img��5   (   
	 � Tag$	 p1��6   $
��Left=�67   $	��100��6R   $��
672,94,0,0q�6_   $	��Top=�6s   $	��100��6�   
   AttackingImageSource$
 assets/Flare_attack.png��6�      DeadImageSource$ assets/Flare_dead.png��6�      IdleImageSource$ assets/Flare_idle.png��6�    J� IsManipulationEnabled .    TakeDamageImageSource$ assets/Flare_hurt.png��63    5   
   -   5        $ e1img��5   (   $	 e1��6   $
��Left=�67   $	��100��6R   $��283,155,0,0q�6_   $	��Top=�6t   $	��100��6�   $
 assets/Riku_attack.png��6�   $ assets/Riku_dead.png��6�   $ assets/Riku_idle.png��6�   $ assets/Riku_hurt.png��6    5   
   -   5        $ e2img��5   (   $	 e2��6   $
��Left=�67   $	��100��6R   $��
178,94,0,0q�6_   $	��Top=�6s   $	��100��6�   $
 assets/Vexen_attack.png��6�   $ assets/Vexen_dead.png��6�   $ assets/Vexen_idle.png��6�   $ assets/Vexen_hurt.png��6   J� RenderTransformOrigin$ 0.5,0.5&�6D  z�5      V� 5      .~�5      ��  �� ScaleY$ 1Q�6%    �� ScaleX$ -1Q�60   �� 5       �� AngleY$ 0Q�6$    �� AngleX$ 0Q�6/   �� 5       �� Angle$ 0Q�6&   T� 5      5      5         5!   
   -   5        $ p2img��5!   (   $	 p2��6   $
��Left=�67   $	��100��6R   $��572,155,0,0q�6_   $	��Top=�6t   $	��100��6�   $
 assets/Xenmas_attack.png��6�   $ assets/Xenmas_dead.png��6�   $ assets/Xenmas_idle.png��6�   $ assets/Xenmas_hurt.png��6  5&      5'      