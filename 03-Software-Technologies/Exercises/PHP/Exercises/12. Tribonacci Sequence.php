<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
    <form>
        N: <input type="text" name="num" />
        <input type="submit" />
    </form>
    <?php
    if (isset($_GET['num']))
    {
        $num = intval($_GET['num']);
        $firstNum = 1;
        $secondNum = 1;
        $thirdNum = 2;
        $currentNum = 0;
        for ($i = 0; $i < $num; $i++)
        {
            if ($i == 0 || $i == 1)
            {
                echo "1 ";
            }
            else if ($i == 2)
            {
                echo "2 ";
            }
            else
            {
                $currentNum = $firstNum + $secondNum + $thirdNum;
                $firstNum = $secondNum;
                $secondNum = $thirdNum;
                $thirdNum = $currentNum;
                echo "$currentNum ";
            }
        }
    }
    ?>
</body>
</html>