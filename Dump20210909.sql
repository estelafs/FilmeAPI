-- MySQL dump 10.13  Distrib 8.0.26, for Win64 (x86_64)
--
-- Host: localhost    Database: cinemadb
-- ------------------------------------------------------
-- Server version	5.7.35-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
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
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20210830143258_Criando','5.0.5'),('20210830170454_Adicionando Relacao entre gerente e cinema','5.0.5'),('20210830173424_Adicionando sessoes','5.0.5');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cinemas`
--

DROP TABLE IF EXISTS `cinemas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cinemas` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` text NOT NULL,
  `EnderecoId` int(11) NOT NULL,
  `GerenteId` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_Cinemas_EnderecoId` (`EnderecoId`),
  KEY `IX_Cinemas_GerenteId` (`GerenteId`),
  CONSTRAINT `FK_Cinemas_Enderecos_EnderecoId` FOREIGN KEY (`EnderecoId`) REFERENCES `enderecos` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Cinemas_Gerentes_GerenteId` FOREIGN KEY (`GerenteId`) REFERENCES `gerentes` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cinemas`
--

LOCK TABLES `cinemas` WRITE;
/*!40000 ALTER TABLE `cinemas` DISABLE KEYS */;
INSERT INTO `cinemas` VALUES (4,'Cinemark',3,1),(5,'Cinelindo',4,1);
/*!40000 ALTER TABLE `cinemas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `enderecos`
--

DROP TABLE IF EXISTS `enderecos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `enderecos` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Logradouro` text,
  `Bairro` text,
  `Numero` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `enderecos`
--

LOCK TABLES `enderecos` WRITE;
/*!40000 ALTER TABLE `enderecos` DISABLE KEYS */;
INSERT INTO `enderecos` VALUES (3,'Av Solar','Esplanada',42),(4,'Rua das Pedras','São Bernadino',505);
/*!40000 ALTER TABLE `enderecos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `filmes`
--

DROP TABLE IF EXISTS `filmes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `filmes` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Titulo` text NOT NULL,
  `Diretor` text NOT NULL,
  `Genero` text NOT NULL,
  `Duracao` int(11) NOT NULL,
  `ClassificacaoEtaria` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `filmes`
--

LOCK TABLES `filmes` WRITE;
/*!40000 ALTER TABLE `filmes` DISABLE KEYS */;
INSERT INTO `filmes` VALUES (1,'Star Wars','George Lucas','Aventura',135,12),(2,'Narnia','Carinha','Aventura',100,0),(3,'Barbie','Dona de Tal','Rosa',95,0),(4,'Practical Magic','Fulana de Tal','Aventura',130,16),(5,'Sherek','Andrew Adamson','Aventura',120,0),(6,'Panico','Adamson','Terror',138,18);
/*!40000 ALTER TABLE `filmes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `gerentes`
--

DROP TABLE IF EXISTS `gerentes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `gerentes` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` text NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gerentes`
--

LOCK TABLES `gerentes` WRITE;
/*!40000 ALTER TABLE `gerentes` DISABLE KEYS */;
INSERT INTO `gerentes` VALUES (1,'Robesvardo, o Gerente');
/*!40000 ALTER TABLE `gerentes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sessoes`
--

DROP TABLE IF EXISTS `sessoes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sessoes` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CinemaId` int(11) NOT NULL,
  `FilmeId` int(11) NOT NULL,
  `HorarioDeEncerramento` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Sessoes_CinemaId` (`CinemaId`),
  KEY `IX_Sessoes_FilmeId` (`FilmeId`),
  CONSTRAINT `FK_Sessoes_Cinemas_CinemaId` FOREIGN KEY (`CinemaId`) REFERENCES `cinemas` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Sessoes_Filmes_FilmeId` FOREIGN KEY (`FilmeId`) REFERENCES `filmes` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sessoes`
--

LOCK TABLES `sessoes` WRITE;
/*!40000 ALTER TABLE `sessoes` DISABLE KEYS */;
INSERT INTO `sessoes` VALUES (2,5,1,'2021-08-31 15:00:00'),(3,4,1,'2021-08-31 19:30:00'),(4,4,6,'2021-08-31 22:00:00'),(5,4,4,'2021-08-31 14:00:00'),(6,5,4,'2021-08-31 18:00:00'),(7,5,3,'2021-08-31 14:30:00'),(8,4,3,'2021-08-31 15:30:00'),(9,4,5,'2021-08-31 19:30:00'),(10,5,2,'2021-08-31 19:30:00'),(11,4,2,'2021-08-31 14:30:00');
/*!40000 ALTER TABLE `sessoes` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-09-09 18:44:02
