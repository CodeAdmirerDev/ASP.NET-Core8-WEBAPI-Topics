﻿using System.ComponentModel.DataAnnotations;

namespace DemoServerAppForHMAC.Models
{
    public class ClientInfo
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string ClientId { get; set; }
        [Required]
        [MaxLength(80)]
        public string ClientName { get; set; }
        [Required]
        [MaxLength(1000)]
        public byte[] ClientSecretKey { get; set; }//Password

        [Required]
        [MaxLength(1000)]
        public byte[] ClientSecretSalt { get; set; }//Password

    }
}
