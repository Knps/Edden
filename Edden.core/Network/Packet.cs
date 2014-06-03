using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using KnpsToolkit.KnpsExtentions;

namespace Edden.core.Network
{
    public class Packet
    {
        public string Id { get; set; }

        public string Content { get; set; }

        public bool IsDeserialized { get; set; }

        public Packet()
        {
            IsDeserialized = false;
        }

        /// <summary>
        /// build to bytes
        /// </summary>
        /// <returns>bytes</returns>
        public static string Format(string packet)
        {
            return packet + "\0";
        }

        /// <summary>
        /// Build packet from data received
        /// </summary>
        /// <param name="data">data received</param>
        public void Deserialize(byte[] data)
        {
            var cData = Encoding.UTF8.GetString(data);

            if (cData.Length < 2 || IsMatch(cData)) return;
            Id = cData.Substring(0, 2);
            Content = cData.Substring(2);
            IsDeserialized = true;
        }

        public static bool IsMatch(string packet)
        {
            return new Regex("\n\0$").IsMatch(packet);
        }

        public static List<Packet> GetPackets(byte[] data)
        {
            var packets = new List<Packet>();
            var sData = Encoding.UTF8.GetString(data).Split("\n\0");

            foreach (var str in sData)
            {
                if (string.IsNullOrEmpty(str))
                    continue;

                var pck = new Packet();
                pck.Deserialize(Encoding.UTF8.GetBytes(str));
                packets.Add(pck);
            }

            return packets;
        } 
    }
}
