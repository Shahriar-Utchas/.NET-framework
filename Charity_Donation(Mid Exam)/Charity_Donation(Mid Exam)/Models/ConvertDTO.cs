using Charity_Donation_Mid_Exam_.DTOs;
using Charity_Donation_Mid_Exam_.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Charity_Donation_Mid_Exam_.Models
{
    public class ConvertDTO
    {
        
        // Convert User
        public static User Convert(UserDTO userDTO)
        {
            return new User
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
                Password = userDTO.Password,
                Role = userDTO.Role
            };

        }
        public static UserDTO Convert(User user)
        {
            return new UserDTO
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password
            };
        }
        public static List<UserDTO> Convert(List<User> users)
        {
            List<UserDTO> userDTOs = new List<UserDTO>();
            foreach (var user in users)
            {
                userDTOs.Add(Convert(user));
            }
            return userDTOs;
        }

        // Convert Donation
        public static Donation Convert(DonationDTO donationDTO)
        {
            return new Donation
            {
                DonorID = donationDTO.DonorID,
                Amount = donationDTO.Amount,
                Date = donationDTO.Date,
                CampainID = donationDTO.CampainID
            };
        }
        public static DonationDTO Convert(Donation donation)
        {
            return new DonationDTO
            {
                DonorID = donation.DonorID,
                Amount = donation.Amount,
                Date = donation.Date,
                CampainID = donation.CampainID
            };
        }
        public static List<DonationDTO> Convert(List<Donation> donations)
        {
            List<DonationDTO> donationDTOs = new List<DonationDTO>();
            foreach (var donation in donations)
            {
                donationDTOs.Add(Convert(donation));
            }
            return donationDTOs;
        }

        // Convert Campain
        public static CampainInfo Convert(CampainInfoDTO campainDTO)
        {
            return new CampainInfo
            {
                CampainID = campainDTO.CampainID,
                campName = campainDTO.campName,
                Desc = campainDTO.Desc
            };
        }
        public static CampainInfoDTO Convert(CampainInfo campain)
        {
            return new CampainInfoDTO
            {
                CampainID = campain.CampainID,
                campName = campain.campName,
                Desc = campain.Desc
            };
        }
        public static List<CampainInfoDTO> Convert(List<CampainInfo> campains)
        {
            List<CampainInfoDTO> campainDTOs = new List<CampainInfoDTO>();
            foreach (var campain in campains)
            {
                campainDTOs.Add(Convert(campain));
            }
            return campainDTOs;
        }
    }
}