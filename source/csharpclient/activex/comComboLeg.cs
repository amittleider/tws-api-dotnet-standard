/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using IBApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace TWSLib
{
    /**
     * @class ComboLeg
     * @brief Class representing a leg within combo orders.
     * @sa Order
     */
    [ComVisible(true)]
    public class ComComboLeg : IComboLeg
    {
        ComboLeg data = new ComboLeg();

        /**
         * @brief The Contract's IB's unique id
         */
        public int ConId
        {
            get { return data.ConId; }
            set { data.ConId = value; }
        }

        /**
          * @brief Select the relative number of contracts for the leg you are constructing. To help determine the ratio for a specific combination order, refer to the Interactive Analytics section of the User's Guide.
          */
        public int Ratio
        {
            get { return data.Ratio; }
            set { data.Ratio = value; }
        }

        /**
         * @brief The side (buy or sell) of the leg:\n
         *      - For individual accounts, only BUY and SELL are available. SSHORT is for institutions.
         */
        public string Action
        {
            get { return data.Action; }
            set { data.Action = value; }
        }
        /**
         * @brief The destination exchange to which the order will be routed.
         */
        public string Exchange
        {
            get { return data.Exchange; }
            set { data.Exchange = value; }
        }

        /**
        * @brief Specifies whether an order is an open or closing order.
        * For instituational customers to determine if this order is to open or close a position.
        *      0 - Same as the parent security. This is the only option for retail customers.\n
        *      1 - Open. This value is only valid for institutional customers.\n
        *      2 - Close. This value is only valid for institutional customers.\n
        *      3 - Unknown
        */
        public int OpenClose
        {
            get { return data.OpenClose; }
            set { data.OpenClose = value; }
        }

        /**
         * @brief For stock legs when doing short selling.
         * Set to 1 = clearing broker, 2 = third party
         */
        public int ShortSaleSlot
        {
            get { return data.ShortSaleSlot; }
            set { data.ShortSaleSlot = value; }
        }

        /**
         * @brief When ShortSaleSlot is 2, this field shall contain the designated location.
         */
        public string DesignatedLocation
        {
            get { return data.DesignatedLocation; }
            set { data.DesignatedLocation = value; }
        }

        /**
         * @brief -
         */
        public int ExemptCode
        {
            get { return data.ExemptCode; }
            set { data.ExemptCode = value; }
        }    

        int IComboLeg.conId { get { return ConId; } set { ConId = value; } }

        int IComboLeg.ratio { get { return Ratio; } set { Ratio = value; } }

        string IComboLeg.action { get { return Action; } set { Action = value; } }

        string IComboLeg.exchange { get { return Exchange; } set { Exchange = value; } }

        int IComboLeg.openClose { get { return OpenClose; } set { OpenClose = value; } }

        int IComboLeg.shortSaleSlot { get { return ShortSaleSlot; } set { ShortSaleSlot = value; } }

        string IComboLeg.designatedLocation { get { return DesignatedLocation; } set { DesignatedLocation = value; } }

        int IComboLeg.exemptCode { get { return ExemptCode; } set { ExemptCode = value; } }

        public static explicit operator ComComboLeg(ComboLeg cl)
        {
            return new ComComboLeg() { data = cl };
        }

        public static explicit operator ComboLeg(ComComboLeg ccl)
        {
            return ccl.data;
        }
    }
}
