-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 06, 2025 at 11:20 AM
-- Server version: 10.4.22-MariaDB
-- PHP Version: 8.1.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `sdd_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `communication`
--

CREATE TABLE `communication` (
  `ID` int(11) NOT NULL,
  `title` varchar(50) NOT NULL,
  `description` varchar(500) NOT NULL,
  `date` date NOT NULL,
  `creator` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `communication`
--

INSERT INTO `communication` (`ID`, `title`, `description`, `date`, `creator`) VALUES
(17, 'testest', 'etstestest', '2025-05-31', 'Karl'),
(18, 'Test ets', 'This comment is used for testing the Comment Log, it was made using Progress Comment on the Team Member Menu.', '2025-06-03', 'Karl'),
(19, 'Test ets', 'This comment is used for testing the Comment Log, it was made using Progress Comment on the Team Member Menu.This comment is used for testing the Comment Log, it was made using Progress Comment on the Team Member Menu.', '2025-06-06', 'Karl'),
(20, 'Sorting Test', 'This comment is used for testing the Comment Log, it was made using Progress Comment on the Team Member Menu.This comment is used for testing the Comment Log, it was made using Progress Comment on the Team Member Menu.', '2025-06-06', 'Karl'),
(21, 'Big Test', 'A software solution designed to streamline user access and role management through a centralized system. It enables secure login functionality, role-based access control (Admin, Project Manager, Team Member), and integration with a backend database', '2025-06-06', 'Karl'),
(22, 'Final test comment', 'Final test', '2025-06-06', 'Karl');

-- --------------------------------------------------------

--
-- Table structure for table `project`
--

CREATE TABLE `project` (
  `ID` int(11) NOT NULL,
  `Title` varchar(50) NOT NULL,
  `Description` varchar(300) NOT NULL,
  `ProjectManagerID` int(50) DEFAULT NULL,
  `Progress` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `project`
--

INSERT INTO `project` (`ID`, `Title`, `Description`, `ProjectManagerID`, `Progress`) VALUES
(5, 'Create Software Solution', 'A software solution designed to streamline user access and role management through a centralized system. It enables secure login functionality, role-based access control (Admin, Project Manager, Team Member), and integration', 9037, 25),
(6, 'Create Software Expermient', 'A software solution designed to streamline user access and role management through a centralized system. It enables secure login functionality, role-based access control (Admin, Project Manager, Team Member), and integration with a backend database', 9012, 50);

-- --------------------------------------------------------

--
-- Table structure for table `projecttask`
--

CREATE TABLE `projecttask` (
  `ID` int(11) NOT NULL,
  `projectID` int(11) NOT NULL,
  `title` varchar(50) NOT NULL,
  `description` varchar(300) NOT NULL,
  `taskCompleted` tinyint(1) NOT NULL,
  `employeeID` int(10) UNSIGNED DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `projecttask`
--

INSERT INTO `projecttask` (`ID`, `projectID`, `title`, `description`, `taskCompleted`, `employeeID`) VALUES
(2, 5, 'Create Software Solution', 'A software solution designed to streamline user access and role management through a centralized system. It enables secure login functionality, role-based access control (Admin, Project Manager, Team Member), and integration', 0, 1275),
(3, 6, 'Coding', 'A software solution designed to streamline user access and role management through a centralized system. It enables secure login functionality, role-based access control (Admin, Project Manager, Team Member), and integration with a backend database', 1, 1002),
(4, 6, 'Experiment preparation', 'A Experiment preparation designed to streamline user access and Experiment preparation through a centralized system. It enables secure Experiment preparation, role-based access control (Admin, Project Manager, Team Member), and Experiment preparation with a backend database', 0, 1153),
(11, 5, 'Create Software ', 'A software solution designed to streamline user access and role management through a centralized system. It enables secure login functionality, role-based access UPDATE TEST', 1, 1002),
(13, 6, 'Coding Hard', 'A software solution designed to streamline user access and role management through a centralized system. It enables secure login functionality, role-based access control (Admin UPDATE TEST TEST', 0, 1275),
(14, 5, 'Coding 3 UPDATED', 'A software solution designed to streamline user access and role management through a centralized system. It enables secure login functionality, role-based access control (Admin, Project Manager, Team Member), and EDIT EDIT', 1, 1275),
(15, 5, 'UPDATE TEST', 'A software solution designed to streamline user access and role management through a centralized system. It enables secure login functionality, role-based access control (Admin, TESTING UPDATE FEATURE', 0, 1002),
(19, 5, 'Test Task', 'Testing Creation of Tasks', 0, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `ID` int(11) NOT NULL,
  `userName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL,
  `role` varchar(50) NOT NULL,
  `employeeID` int(10) UNSIGNED DEFAULT NULL,
  `ProjectManagerID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`ID`, `userName`, `role`, `employeeID`, `ProjectManagerID`) VALUES
(1, 'Karl', 'teamMember', 1002, NULL),
(2, 'Amy', 'Admin', NULL, NULL),
(3, 'James', 'projectManager', NULL, 9012),
(6, 'Joe', 'teamMember', 1153, NULL),
(7, 'Klana', 'teamMember', 1275, NULL),
(9, 'Morgan', 'projectManager', NULL, 9037),
(10, 'TestProjectManager', 'projectManager', NULL, 9050),
(11, 'TestProjectManager2', 'projectManager', NULL, 9055),
(12, 'TestProjectManagerNoProj', 'projectManager', NULL, 9040);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `communication`
--
ALTER TABLE `communication`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `project`
--
ALTER TABLE `project`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `ProjectManager` (`ProjectManagerID`);

--
-- Indexes for table `projecttask`
--
ALTER TABLE `projecttask`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `fk_projectID` (`projectID`),
  ADD KEY `fk_user_employee` (`employeeID`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `employeeID_2` (`userName`,`role`) USING BTREE,
  ADD UNIQUE KEY `employeeID` (`employeeID`),
  ADD UNIQUE KEY `ProjectManagerID` (`ProjectManagerID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `communication`
--
ALTER TABLE `communication`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- AUTO_INCREMENT for table `project`
--
ALTER TABLE `project`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `projecttask`
--
ALTER TABLE `projecttask`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `project`
--
ALTER TABLE `project`
  ADD CONSTRAINT `fk_ManagerID` FOREIGN KEY (`ProjectManagerID`) REFERENCES `user` (`ProjectManagerID`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Constraints for table `projecttask`
--
ALTER TABLE `projecttask`
  ADD CONSTRAINT `fk_projectID` FOREIGN KEY (`projectID`) REFERENCES `project` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_user_employee` FOREIGN KEY (`employeeID`) REFERENCES `user` (`employeeID`) ON DELETE SET NULL ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
