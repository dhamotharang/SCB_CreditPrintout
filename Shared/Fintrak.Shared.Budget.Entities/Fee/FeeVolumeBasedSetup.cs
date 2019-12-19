﻿using Fintrak.Shared.Common.Contracts;
using Fintrak.Shared.Common.Core;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace Fintrak.Shared.Budget.Entities
{
    public partial class FeeVolumeBasedSetup : EntityBase, IIdentifiableEntity
    {
        [DataMember]
        [Browsable (false)]
        public int FeeVolumeBasedSetupId { get; set; }

        [DataMember]
        [Required]
        public string FeeCode { get; set; }

        [DataMember]
        [Required]
        public string MakeUpCode { get; set; }

        [DataMember]
        [Required]
        public string ReviewCode { get; set; }

        [DataMember]
        [Required]
        public string Year { get; set; }

        public int EntityId
        {
            get
            {
                return FeeVolumeBasedSetupId;
            }
        }
    }
}