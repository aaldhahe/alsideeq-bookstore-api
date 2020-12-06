-- MySQL dump 10.13  Distrib 5.7.17, for macos10.12 (x86_64)
--
-- Host: alsideeq-bookstore-instance.clslxbbfn4dw.us-east-2.rds.amazonaws.com    Database: Alsideeq_BookStore_DB
-- ------------------------------------------------------
-- Server version	8.0.20

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
SET @MYSQLDUMP_TEMP_LOG_BIN = @@SESSION.SQL_LOG_BIN;
SET @@SESSION.SQL_LOG_BIN= 0;

--
-- GTID state at the beginning of the backup 
--

SET @@GLOBAL.GTID_PURGED='';

--
-- Table structure for table `Address`
--

DROP TABLE IF EXISTS `Address`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Address` (
  `address_id` varchar(50) NOT NULL,
  `address` varchar(50) NOT NULL,
  `address_2` varchar(50) DEFAULT NULL,
  `city` varchar(50) NOT NULL,
  `zip_code` varchar(50) NOT NULL,
  `country` varchar(50) NOT NULL,
  `state` varchar(50) NOT NULL,
  PRIMARY KEY (`address_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Address`
--

LOCK TABLES `Address` WRITE;
/*!40000 ALTER TABLE `Address` DISABLE KEYS */;
INSERT INTO `Address` VALUES ('041e7c30-b5a8-4731-b5d8-8db1e6e4fd1c','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('052a4c6d-1329-441d-9de0-a0911a308246','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('0bad4bb6-a2ee-4512-8c57-8a1e73c6df73','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('0ec7e390-0946-4b2c-976f-8f8bd681309d','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('0ed59162-f7ff-4f23-8a05-3677dbc8d884','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('12c60c18-58bb-4a4a-b649-7b50252b51cf','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('16086e04-dd03-4f38-9df0-3f5a56bcfd61','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('17280a51-800e-4a7a-8e8e-b548312507e7','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('176962bc-53f6-44d8-97ae-cc6da142f2e5','1234 main st','apt. 6','Canton','48187','USA','48187'),('181af5a4-b41a-4348-96ca-443bac917ff4','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('18c27f19-deee-49b2-bd69-bd4ec54ed5a6','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('19d79f27-3bc4-4e16-aee6-1af659e1da65','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('1b3fb9b3-8832-4233-b5f2-30a3951d2e47','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('1db5bc0c-e67e-4978-8761-68971bee2d8d','1234 main st','apt. 6','Canton','48187','USA','48187'),('208316bb-1723-4a82-abdc-7909d99be853','1234 main st','apt. 6','Canton','48187','USA','48187'),('2175206d-fff3-4d88-ba56-2f2bd63fd865','1234 main st','apt. 6','Canton','48187','USA','48187'),('21916487-a460-4a95-95f9-71089a35dd60','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('254da359-74e3-4103-98f7-a5b0a4d96e83','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('2b9be56f-84ff-42d2-b463-452b99b577db','','','','','USA',''),('2bfcf9e6-d03f-4538-870b-11834f99601a','1234 main st','apt. 6','Canton','48187','USA','48187'),('32a60560-5b91-4927-83b6-2adbd63c17bc','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('3512a097-e862-44bb-ae31-283ac09ee0eb','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('369a1b48-34fc-420f-8b16-a6d4c8208499','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('373c3e4f-b8bb-4e30-97a4-78726a584dae','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('39bf1db9-9d50-4804-b88b-e0322bc4d419','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('3e3e6a2f-8948-462a-8aa9-d02f2eca7328','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('478fb361-811b-4148-a29e-8af4c40ca3eb','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('47d18973-b268-41d4-a647-8ac8808d5656','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('4b08fc78-f158-4506-b5c6-7ab1ffa2f9f3','','','','','USA',''),('4b0d0130-58cc-488f-bbed-bc35eff58241','1234 main st','apt. 6','Canton','48187','USA','48187'),('4c29a94f-7735-4b7c-a7d1-c8bedbbaef6a','1234 main st','apt. 6','Canton','48187','USA','48187'),('50e0f116-c2e9-4e52-9d0f-8d562f9968c0','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('540df951-a987-4096-8fa8-97c94ed025c5','1234 main st','apt. 6','Canton','48187','USA','48187'),('54c7d586-6cb5-43be-bdf5-d9b1576d4b8b','1234 main st','apt. 6','Canton','48187','USA','48187'),('589c8c6c-14de-11eb-91f2-02d98744b53e','4234 evergreen rd','apt 123','Dearborn','48126','USA','Michigan'),('5b2c2190-14de-11eb-91f2-02d98744b53e','4234 evergreen rd','apt 123','Dearborn','48126','USA','Michigan'),('5ba8140c-14de-11eb-91f2-02d98744b53e','4234 evergreen rd','apt 123','Dearborn','48126','USA','Michigan'),('5bbced88-6a9f-4600-a718-49b9e5a8f316','1234 main st','apt. 6','Canton','48187','USA','48187'),('5c05ffc8-14de-11eb-91f2-02d98744b53e','4234 evergreen rd','apt 123','Dearborn','48126','USA','Michigan'),('5c359683-14e8-406a-ac44-8f90703521cd','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('5c449c23-14de-11eb-91f2-02d98744b53e','4234 evergreen rd','apt 123','Dearborn','48126','USA','Michigan'),('5c9158ae-14de-11eb-91f2-02d98744b53e','4234 evergreen rd','apt 123','Dearborn','48126','USA','Michigan'),('619275e5-0ea1-4b76-88a3-404c586c8030','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('619f4ed4-a444-425c-a866-efc0ce91d4de','1234 main st','apt. 6','Canton','48187','USA','48187'),('640baf4e-80e3-4204-9dbb-1e1c4f9b6320','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('652a2f63-14de-11eb-91f2-02d98744b53e','4234 evergreen rd','apt 123','Dearborn','48126','USA','Michigan'),('66c83240-8d05-444c-9eda-a8bb07f8ab30','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('6795e82a-e112-4cca-a04f-4ed584d40880','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('713aee7b-99a9-4e14-bae6-44c7678982a0','44670 Heather Ln','','Canton','48187','USA','48187'),('7226bee5-d934-4cdb-8a3d-f3352146e020','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('750c7d17-eed1-4ac2-953b-cbb701ee635e','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('778c387d-56a3-4376-b4d0-0410edc582b0','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('779184a0-7adc-433b-9889-492458d62617','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('7c1f1b36-61fd-422a-bfc1-afc65b225739','1234 main st','apt. 6','Canton','48187','USA','48187'),('825ca2e8-6a1f-4f97-84a6-905cf73da90b','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('890acadb-d328-4e77-ae3d-98e7faf7f789','1234 main st','apt. 6','Canton','48187','USA','48187'),('8b7cf35e-5547-46a2-9991-6feb1928b2b7','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('8e75c22b-9d12-44be-acb1-4e0278dfd455','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('92c26a18-2bfe-4c06-aa7c-00ef90915a7b','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('9491215c-5686-45ab-9329-d68dc78daa4f','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('9b84c8e0-b3a5-4756-a146-675086d593cd','1234 main st','apt. 6','Canton','48187','USA','48187'),('9bb19b10-cbec-41ae-9c52-db0d131ec8db','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('a4becf39-9eff-4147-b9a8-c567031a970e','1234 main st','apt. 6','Canton','48187','USA','48187'),('a4e20c68-96c7-47c3-bec5-8192c301d3aa','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('a52f8ef6-b257-456d-90b4-1d2ddda664f4','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('a7d81fc4-6002-4876-b1ee-0007c8be88d7','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('a9affe62-ef0f-4258-a40e-e5d1ad529af5','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('aa253ee3-5122-4897-a747-5f92bff7665a','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('ae55b46d-a2b6-4c47-a0b4-54e4b1cfb495','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('b4215c6f-d922-4646-bc92-1f623c611d25','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('b4b26c7f-ae8c-4849-8b74-36606bbd8ec2','1234 main st','apt. 6','Canton','48187','USA','48187'),('bb232f15-dd8f-48b2-a3e4-3d37baff1c60','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('c1848956-665b-4b36-9248-077f2e98d9a7','1234 main st','apt. 6','Canton','48187','USA','48187'),('c42337e7-d612-40d8-8333-83de0b7f808c','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('c70570f8-8492-461f-b225-75adb1b124f9','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('c781314a-bc4d-4134-a578-4f3fff7d98a9','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('cc28cbf7-ccfc-4984-9187-5999c4cff637','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('ccb1a934-37fd-4387-98cc-030f9c6fc4d6','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('d3320427-e528-4c3e-b95c-1d6cc3e434c5','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('d3e36d14-6d4c-4b04-a3a8-849ea3606613','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('d426f412-8256-4f7a-ae61-34f9742937bc','1234 main st','apt. 6','Canton','48187','USA','48187'),('d547ad34-8822-455a-8151-4662a866172b','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('d78c0857-afe2-4108-9551-54f610ff52fb','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('d9247a0f-4caa-412b-a76d-01de99fd016a','44670 Heather Ln','','Canton','48187','USA','48187'),('e0026593-acfc-4daf-923f-18a0f73f737c','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('e5646e06-a55e-424f-82a9-fd8a3e7bc016','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('e9d78c25-ca91-4d1d-b676-1104f3e89c11','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('ea46828a-71c6-4c03-8e26-2a4ca933f845','234 hello st','apt 13','Dearborn','48126','USA','Michigan'),('eac41a62-c1ab-4983-a30b-163ce462d589','123123 morrow circ st','apt 45','Dearborn Heights','48127','USA','Michigan'),('eb142e26-80e0-4ff4-8574-6be96617bc4b','1234 main st','apt. 6','Canton','48187','USA','48187'),('f1ddac41-bf80-4313-a111-9e20f842949c','1234 main st','apt. 6','Canton','48187','USA','48187'),('f6b8fb1b-fabb-4453-bd53-2ede8fb7b01a','234 hello st','apt 13','Dearborn','48126','USA','Michigan');
/*!40000 ALTER TABLE `Address` ENABLE KEYS */;
UNLOCK TABLES;
SET @@SESSION.SQL_LOG_BIN = @MYSQLDUMP_TEMP_LOG_BIN;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-12-05 21:46:22
