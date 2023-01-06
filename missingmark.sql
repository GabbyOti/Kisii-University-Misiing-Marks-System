-- phpMyAdmin SQL Dump
-- version 3.3.9
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Nov 30, 2018 at 07:50 PM
-- Server version: 5.5.8
-- PHP Version: 5.3.5

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `missingmark`
--

-- --------------------------------------------------------

--
-- Table structure for table `application`
--
create database missingmark;
use missingmark; 

CREATE TABLE IF NOT EXISTS `application` (
  `Serial_No` varchar(20) NOT NULL,
  `Registration_No` varchar(20) NOT NULL,
  `Course_Id` varchar(20) NOT NULL,
  `semester` varchar(4) NOT NULL,
  `Year_Of_Study` varchar(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `application`
--


-- --------------------------------------------------------

--
-- Table structure for table `course`
--

CREATE TABLE IF NOT EXISTS `course` (
  `course_Id` varchar(20) NOT NULL,
  `course_Name` varchar(20) NOT NULL,
  `Lecturer_Name` varchar(20) NOT NULL,
  `year` varchar(4) NOT NULL,
  `semester` varchar(4) NOT NULL,
  `programme_Id` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `course`
--


-- --------------------------------------------------------

--
-- Table structure for table `department`
--

CREATE TABLE IF NOT EXISTS `department` (
  `department_Id` varchar(20) NOT NULL,
  `department_Name` varchar(20) NOT NULL,
  `office` varchar(20) NOT NULL,
  `school_Id` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `department`
--


-- --------------------------------------------------------

--
-- Table structure for table `faculty`
--

CREATE TABLE IF NOT EXISTS `faculty` (
  `school_Id` varchar(20) NOT NULL,
  `school_Name` varchar(20) NOT NULL,
  `office` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `faculty`
--

INSERT INTO `faculty` (`school_Id`, `school_Name`, `office`) VALUES
('fdghjk', 'fghjkl', 'chgvbjnkm,.');

-- --------------------------------------------------------

--
-- Table structure for table `lecturer`
--

CREATE TABLE IF NOT EXISTS `lecturer` (
  `PFNO` varchar(20) NOT NULL,
  `Lecturer_Name` varchar(20) NOT NULL,
  `phone` int(10) NOT NULL,
  `Department_Id` varchar(20) NOT NULL,
  `Email` varchar(25) NOT NULL,
  `Employment_Year` varchar(4) NOT NULL,
  `Gender` varchar(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `lecturer`
--


-- --------------------------------------------------------

--
-- Table structure for table `programme`
--

CREATE TABLE IF NOT EXISTS `programme` (
  `programme_Id` varchar(20) NOT NULL,
  `programme_Name` varchar(20) NOT NULL,
  `department_Id` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `programme`
--

INSERT INTO `programme` (`programme_Id`, `programme_Name`, `department_Id`) VALUES
('ghjkl;', 'fghjkl', 'ghjkl;');
