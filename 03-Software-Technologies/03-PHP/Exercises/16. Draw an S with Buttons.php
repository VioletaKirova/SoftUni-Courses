<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>
</head>
<body>
<?php
 for ($i = 0; $i < 9; $i++)
 {
     if ($i == 0 || $i == 4 || $i == 8)
     {
         for ($j = 0; $j < 5; $j++)
         { ?>
             <button style="background-color: blue">1</button>
         <?php }
     }
     else if ($i == 1 || $i == 2 || $i == 3)
     {
         for ($j = 0; $j < 5; $j++)
         {
             if ($j == 0)
             { ?>
                <button style="background-color: blue">1</button>
             <?php }
             else
             { ?>
                 <button>0</button>
             <?php }
         }
     }
     else
     {
         for ($j = 0; $j < 5; $j++)
         {
             if ($j == 4)
             { ?>
                 <button style="background-color: blue">1</button>
             <?php }
             else
             { ?>
                 <button>0</button>
             <?php }
         }
     }
     ?>
    <br>
<?php
 }
?>
</body>
</html>