<?php
include('connection.php');

$sql = "SELECT * FROM result ORDER BY score DESC";
$result = mysqli_query($conn, $sql);

if (mysqli_num_rows($result) > 0) {
    while ($row = mysqli_fetch_assoc($result)) {
        echo "username:".$row['username']."|score:".$row['score']."|time:".$row['time'].";";
    }
}

?>