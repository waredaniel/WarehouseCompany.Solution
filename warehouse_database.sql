-- MySQL dump 10.13  Distrib 8.0.27, for macos11 (x86_64)
--
-- Host: localhost    Database: warehouse_company
-- ------------------------------------------------------
-- Server version	8.0.27

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
-- Table structure for table `__EFMigrationsHistory`
--

DROP TABLE IF EXISTS `__EFMigrationsHistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__EFMigrationsHistory`
--

LOCK TABLES `__EFMigrationsHistory` WRITE;
/*!40000 ALTER TABLE `__EFMigrationsHistory` DISABLE KEYS */;
INSERT INTO `__EFMigrationsHistory` VALUES ('20220803165546_Initial','5.0.0'),('20220803180841_ProductName','5.0.0'),('20220803215701_Order','5.0.0');
/*!40000 ALTER TABLE `__EFMigrationsHistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Orders`
--

DROP TABLE IF EXISTS `Orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Orders` (
  `OrderId` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `OrderDate` datetime(6) NOT NULL,
  `OrderQuantity` int NOT NULL,
  `OrderPrice` int NOT NULL,
  `OrderStatus` tinyint(1) NOT NULL,
  PRIMARY KEY (`OrderId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Orders`
--

LOCK TABLES `Orders` WRITE;
/*!40000 ALTER TABLE `Orders` DISABLE KEYS */;
INSERT INTO `Orders` VALUES (1,'Simba','2022-08-03 09:49:00.000000',100,99,1);
/*!40000 ALTER TABLE `Orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ProductOrder`
--

DROP TABLE IF EXISTS `ProductOrder`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ProductOrder` (
  `ProductOrderId` int NOT NULL AUTO_INCREMENT,
  `ProductId` int NOT NULL,
  `OrderId` int NOT NULL,
  PRIMARY KEY (`ProductOrderId`),
  KEY `IX_ProductOrder_OrderId` (`OrderId`),
  KEY `IX_ProductOrder_ProductId` (`ProductId`),
  CONSTRAINT `FK_ProductOrder_Orders_OrderId` FOREIGN KEY (`OrderId`) REFERENCES `Orders` (`OrderId`) ON DELETE CASCADE,
  CONSTRAINT `FK_ProductOrder_Products_ProductId` FOREIGN KEY (`ProductId`) REFERENCES `Products` (`ProductId`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ProductOrder`
--

LOCK TABLES `ProductOrder` WRITE;
/*!40000 ALTER TABLE `ProductOrder` DISABLE KEYS */;
INSERT INTO `ProductOrder` VALUES (1,2,1);
/*!40000 ALTER TABLE `ProductOrder` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Products`
--

DROP TABLE IF EXISTS `Products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Products` (
  `ProductId` int NOT NULL AUTO_INCREMENT,
  `ProductDescription` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ProductPrice` int NOT NULL,
  `ProductName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`ProductId`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Products`
--

LOCK TABLES `Products` WRITE;
/*!40000 ALTER TABLE `Products` DISABLE KEYS */;
INSERT INTO `Products` VALUES (1,'Cartoon Anvil',22,'Anvil'),(2,'Cleaning tool',10,'Kitchen Cleaner'),(3,'200 ml glass cup',1,'Cup'),(4,'Fit for Iphone 15',1,'Iphone Case'),(5,'20 cts',10,'Paper Towels(20 cts)'),(6,'200 cts',70,'Paper Towels(200 cts)'),(7,'500 cts',150,'Paper Towels(500 cts)'),(8,'Iphone Case (SE)',1,'Iphone Case (SE)'),(9,'Brita Water Filter, 200 cts',300,'Water Filter (200 cts)'),(10,'Brita Water Filter, 100 cts',50,'Water Filter (100 cts)'),(11,'1,000 cts',280,'Paper Towels(1,000 cts)'),(12,'1 bottle, 400 ml',12,'Keurig Descaling Solution'),(13,'24 cts',16,'Original Donut Shop Caramel Apple Pie Keurig K-Cup Coffee Pods Flavored Coffee Medium Roast'),(14,'24 cts',14,'McCafe Toffee Almond Medium Roast Coffee'),(15,'22 cts',19,'Starbucks Medium Roast K-Cup Coffee Pods'),(16,'12 cts',4,'Premium Roast Medium Roast Coffee'),(17,'18 cts',23,'VitaCup Slim Diet & Metabolism Medium Roast Coffee'),(18,NULL,0,'test1'),(19,NULL,0,'test2'),(20,NULL,0,'test3'),(21,NULL,0,'test4'),(22,NULL,0,'test5'),(23,NULL,0,'test6'),(24,NULL,0,'test7'),(25,NULL,0,'test7'),(26,NULL,0,'test8');
/*!40000 ALTER TABLE `Products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ProductSupplier`
--

DROP TABLE IF EXISTS `ProductSupplier`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ProductSupplier` (
  `ProductSupplierId` int NOT NULL AUTO_INCREMENT,
  `ProductId` int NOT NULL,
  `SupplierId` int NOT NULL,
  PRIMARY KEY (`ProductSupplierId`),
  KEY `IX_ProductSupplier_ProductId` (`ProductId`),
  KEY `IX_ProductSupplier_SupplierId` (`SupplierId`),
  CONSTRAINT `FK_ProductSupplier_Products_ProductId` FOREIGN KEY (`ProductId`) REFERENCES `Products` (`ProductId`) ON DELETE CASCADE,
  CONSTRAINT `FK_ProductSupplier_Suppliers_SupplierId` FOREIGN KEY (`SupplierId`) REFERENCES `Suppliers` (`SupplierId`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ProductSupplier`
--

LOCK TABLES `ProductSupplier` WRITE;
/*!40000 ALTER TABLE `ProductSupplier` DISABLE KEYS */;
INSERT INTO `ProductSupplier` VALUES (1,1,1),(2,2,1),(3,3,5),(4,4,5),(5,5,5),(6,6,5),(7,7,5),(8,8,5),(9,9,5),(10,10,5),(11,11,5),(12,12,1),(13,13,5),(14,14,5),(15,15,5),(16,16,5),(17,17,5),(18,18,1),(19,19,1),(20,20,1),(21,21,1),(22,22,1),(23,23,1),(24,24,1),(25,25,1),(26,26,1);
/*!40000 ALTER TABLE `ProductSupplier` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Suppliers`
--

DROP TABLE IF EXISTS `Suppliers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Suppliers` (
  `SupplierId` int NOT NULL AUTO_INCREMENT,
  `SupplierName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `SupplierAddress` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `SupplierCountry` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`SupplierId`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Suppliers`
--

LOCK TABLES `Suppliers` WRITE;
/*!40000 ALTER TABLE `Suppliers` DISABLE KEYS */;
INSERT INTO `Suppliers` VALUES (1,'AcmeCo','1234 Main St','Canada'),(2,'TDD','1 St, Los Angels, Ca 90000','USA'),(4,NULL,NULL,NULL),(5,'DailyItems','2 St, Los Angels, Ca 90000','USA');
/*!40000 ALTER TABLE `Suppliers` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-08-04 10:25:39
