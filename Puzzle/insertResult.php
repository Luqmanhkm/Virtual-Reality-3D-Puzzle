<?php
include('connection.php');

$username = $_POST['addUsername'];
$score = $_POST['addScore'];
$time = $_POST['addTime'];

$scoreFloat = (float) $score;
$timeFloat = (float) $time;

$sql = "insert into result (username, score, time) values ('".$username."','".$scoreFloat."','".$timeFloat."')";
$result = mysqli_query($conn, $sql);
?>