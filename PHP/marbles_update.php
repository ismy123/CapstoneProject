<?php
	$userID = $_POST["userID"];
	$object = $_POST["object"];

	$con = mysqli_connect("localhost", "student", "student1234", "Dodori");

	if($object == "marble01")
		$sql = "update Marbles SET marble01 = marble01 + 1 WHERE userID = '$userID'";
	else if($object == "marble02")
		$sql = "update Marbles SET marble02 = marble02 + 1 WHERE userID = '$userID'";
	else
		$sql = "update Marbles SET marble03 = marble03 + 1 WHERE userID = '$userID'";

	mysqli_query($con, $sql);
	mysqli_close($con);
?>