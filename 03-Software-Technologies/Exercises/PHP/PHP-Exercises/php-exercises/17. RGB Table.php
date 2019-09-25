<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>
	<style>
		table * {
			border: 1px solid black;
			width: 50px;
			height: 50px;
		}
    </style>
</head>
<body>
<table>
    <tr>
        <td>
            Red
        </td>
        <td>
            Green
        </td>
        <td>
            Blue
        </td>
    </tr>
    <?php
        $red = array(0, 0, 0);
        $green = array(0, 0, 0);
        $blue = array(0, 0, 0);
        for ($i = 0; $i < 5; $i++)
        {
            $red[0] += 51;
            $green[1] += 51;
            $blue[2] += 51;
            $colourRed = implode(", ", $red);
            $colourGreen = implode(", ", $green);
            $colourBlue = implode(", ", $blue);
            ?>
    <tr>
        <td style="background-color: rgb(<?= $colourRed ?>)"></td>
        <td style="background-color: rgb(<?= $colourGreen ?>)"></td>
        <td style="background-color: rgb(<?= $colourBlue ?>)"></td>
    </tr>
            <?php
        }
    ?>
</table>
</body>
</html>