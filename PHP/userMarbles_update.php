<?php
	$userID = $_POST["userID"];
	$object = $_GET["object"];

	$con = mysqli_connect("localhost", "student", "student1234", "Dodori");

	switch($object) {
		case "marble01":
			$sql = "update Marbles SET marble01 = marble01 + 1 WHERE userID = '$userID'";
			break;
		case "marble02":
			$sql = "update Marbles SET marble02 = marble02 + 1 WHERE userID = '$userID'";
			break;
		case "marble03":
			$sql = "update Marbles SET marble03 = marble03 + 1 WHERE userID = '$userID'";
			break;
	}

	mysqli_query($con, $sql);
	mysqli_close($con);
?>