<?php
	$userID = $_POST["userID"];
	$object = $_GET["object"];

	$con = mysqli_connect("localhost", "student", "student1234", "Dodori");

	switch($object) {
		case "item01":
			$sql = "update Items SET item01 = item01 + 1 WHERE userID = '$userID'";
			break;
		case "item02":
			$sql = "update Items SET item02 = item02 + 1 WHERE userID = '$userID'";
			break;
	}

	mysqli_query($con, $sql);
	mysqli_close($con);
?>