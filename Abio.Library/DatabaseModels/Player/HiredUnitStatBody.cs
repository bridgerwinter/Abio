﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Abio.Library.DatabaseModels;

public partial class HiredUnitStatBody
{
    public Guid HiredUnitStatBodyId { get; set; }

    public byte? Arteries { get; set; }

    public byte? Head { get; set; }

    public byte? Hair { get; set; }

    public byte? LeftEye { get; set; }

    public byte? RightEye { get; set; }

    public byte? Nose { get; set; }

    public byte? Mouth { get; set; }

    public byte? Teeth { get; set; }

    public byte? LeftEar { get; set; }

    public byte? RightEar { get; set; }

    public byte? Brain { get; set; }

    public byte? Neck { get; set; }

    public byte? Trachea { get; set; }

    public byte? Larynx { get; set; }

    public byte? LeftShoulder { get; set; }

    public byte? RightShoulder { get; set; }

    public byte? Chest { get; set; }

    public byte? Heart { get; set; }

    public byte? Lungs { get; set; }

    public byte? Stomach { get; set; }

    public byte? LeftUpperArm { get; set; }

    public byte? RightUpperArm { get; set; }

    public byte? LeftElbow { get; set; }

    public byte? RightElbow { get; set; }

    public byte? LeftLowerArm { get; set; }

    public byte? RightLowerArm { get; set; }

    public byte? LeftHand { get; set; }

    public byte? RightHand { get; set; }

    public byte? Genitals { get; set; }

    public byte? Butt { get; set; }

    public byte? LeftUpperLeg { get; set; }

    public byte? RightUpperLeg { get; set; }

    public byte? LeftKnee { get; set; }

    public byte? RightKnee { get; set; }

    public byte? LeftLowerLeg { get; set; }

    public byte? RightLowerLeg { get; set; }

    public byte? LeftFoot { get; set; }

    public byte? RightFoot { get; set; }

    public virtual ICollection<HiredUnitStat> HiredUnitStat { get; set; } = new List<HiredUnitStat>();
}