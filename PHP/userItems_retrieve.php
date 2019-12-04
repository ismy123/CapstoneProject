<?php
	$userID = $_POST["userID"];

	$con = mysqli_connect("localhost", "student", "student1234", "Dodori");
	$sql = "select * 
	 		FROM Items
			WHERE userID = '$userID'";

	$result = mysqli_query($con, $sql);  // $sql 에 저장된 명령 실행
	echo mysqli_error($con);
	while($row = mysqli_fetch_array($result)) {
		echo $row['item01']."*";
		echo $row['item02']."*";
	}
    mysqli_close($con);
?>