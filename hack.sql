-- MySQL dump 10.16  Distrib 10.3.8-MariaDB, for Win64 (AMD64)
--
-- Host: localhost    Database: hackquestion
-- ------------------------------------------------------
-- Server version	10.3.8-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(95) COLLATE latin1_general_ci NOT NULL,
  `ProductVersion` varchar(32) COLLATE latin1_general_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `category`
--

DROP TABLE IF EXISTS `category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `category` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'Primary Key To this Table, Unique key',
  `Name` varchar(50) COLLATE latin1_general_ci NOT NULL COMMENT 'Name of Catgegory',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `question`
--

DROP TABLE IF EXISTS `question`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `question` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'PRIMARY KEY FOR This table - records',
  `Description` text COLLATE latin1_general_ci NOT NULL COMMENT 'Question.',
  `Tips` text COLLATE latin1_general_ci DEFAULT NULL COMMENT 'Tips',
  `Answer` text COLLATE latin1_general_ci DEFAULT NULL COMMENT 'Answer',
  `Seconds` int(11) DEFAULT NULL COMMENT 'Time in Milliseconds to respose',
  `CategoryId` int(11) NOT NULL COMMENT 'Foreign key to Category.ID',
  `CreateDate` date NOT NULL DEFAULT current_timestamp(),
  `Deleted` bit(1) NOT NULL DEFAULT b'0' COMMENT 'Indicate if record was delete',
  `Published` bit(1) DEFAULT b'1' COMMENT 'Indicate this question was verified!',
  PRIMARY KEY (`Id`),
  KEY `QuestionFK` (`CategoryId`),
  FULLTEXT KEY `QuestionIdx` (`Description`,`Tips`,`Answer`),
  CONSTRAINT `QuestionFK` FOREIGN KEY (`CategoryId`) REFERENCES `category` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=66 DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci COMMENT='Question';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `role`
--

DROP TABLE IF EXISTS `role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `role` (
  `Id` varchar(127) COLLATE latin1_general_ci NOT NULL,
  `ConcurrencyStamp` longtext COLLATE latin1_general_ci DEFAULT NULL,
  `Name` varchar(256) COLLATE latin1_general_ci DEFAULT NULL,
  `NormalizedName` varchar(256) COLLATE latin1_general_ci DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `roleclaim`
--

DROP TABLE IF EXISTS `roleclaim`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `roleclaim` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ClaimType` longtext COLLATE latin1_general_ci DEFAULT NULL,
  `ClaimValue` longtext COLLATE latin1_general_ci DEFAULT NULL,
  `RoleId` varchar(127) COLLATE latin1_general_ci NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_RoleClaim_RoleId` (`RoleId`),
  CONSTRAINT `FK_RoleClaim_Role_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `role` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user` (
  `Id` varchar(127) COLLATE latin1_general_ci NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  `ConcurrencyStamp` longtext COLLATE latin1_general_ci DEFAULT NULL,
  `Email` varchar(256) COLLATE latin1_general_ci DEFAULT NULL,
  `EmailConfirmed` bit(1) NOT NULL,
  `LockoutEnabled` bit(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `NormalizedEmail` varchar(256) COLLATE latin1_general_ci DEFAULT NULL,
  `NormalizedUserName` varchar(256) COLLATE latin1_general_ci DEFAULT NULL,
  `PasswordHash` longtext COLLATE latin1_general_ci DEFAULT NULL,
  `PhoneNumber` longtext COLLATE latin1_general_ci DEFAULT NULL,
  `PhoneNumberConfirmed` bit(1) NOT NULL,
  `SecurityStamp` longtext COLLATE latin1_general_ci DEFAULT NULL,
  `TwoFactorEnabled` bit(1) NOT NULL,
  `UserName` varchar(256) COLLATE latin1_general_ci DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `userclaim`
--

DROP TABLE IF EXISTS `userclaim`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `userclaim` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ClaimType` longtext COLLATE latin1_general_ci DEFAULT NULL,
  `ClaimValue` longtext COLLATE latin1_general_ci DEFAULT NULL,
  `UserId` varchar(127) COLLATE latin1_general_ci NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_UserClaim_UserId` (`UserId`),
  CONSTRAINT `FK_UserClaim_User_UserId` FOREIGN KEY (`UserId`) REFERENCES `user` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `userlogin`
--

DROP TABLE IF EXISTS `userlogin`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `userlogin` (
  `LoginProvider` varchar(127) COLLATE latin1_general_ci NOT NULL,
  `ProviderKey` varchar(127) COLLATE latin1_general_ci NOT NULL,
  `ProviderDisplayName` longtext COLLATE latin1_general_ci DEFAULT NULL,
  `UserId` varchar(127) COLLATE latin1_general_ci NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_UserLogin_UserId` (`UserId`),
  CONSTRAINT `FK_UserLogin_User_UserId` FOREIGN KEY (`UserId`) REFERENCES `user` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `userrole`
--

DROP TABLE IF EXISTS `userrole`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `userrole` (
  `UserId` varchar(127) COLLATE latin1_general_ci NOT NULL,
  `RoleId` varchar(127) COLLATE latin1_general_ci NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_UserRole_RoleId` (`RoleId`),
  CONSTRAINT `FK_UserRole_Role_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `role` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_UserRole_User_UserId` FOREIGN KEY (`UserId`) REFERENCES `user` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `usertoken`
--

DROP TABLE IF EXISTS `usertoken`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usertoken` (
  `UserId` varchar(127) COLLATE latin1_general_ci NOT NULL,
  `LoginProvider` varchar(127) COLLATE latin1_general_ci NOT NULL,
  `Name` varchar(127) COLLATE latin1_general_ci NOT NULL,
  `Value` longtext COLLATE latin1_general_ci DEFAULT NULL,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`),
  CONSTRAINT `FK_UserToken_User_UserId` FOREIGN KEY (`UserId`) REFERENCES `user` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-10-29 17:29:06
