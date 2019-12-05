<?php
	$userID = $_POST["userID"];
	$object = $_POST["object"];
	
	$con = mysqli_connect("localhost", "student", "student1234", "Dodori");

	if($object == "item01")
			$sql = "update Items SET item01 = item01 + 1 WHERE userID = '$userID'";
	else
			$sql = "update Items SET item02 = item02 + 1 WHERE userID = '$userID'";
		
	mysqli_query($con, $sql);
	mysqli_close($con);
?>