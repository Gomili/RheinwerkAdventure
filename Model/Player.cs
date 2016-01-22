﻿using System;
using System.Collections.Generic;

namespace RheinwerkAdventure.Model
{
    /// <summary>
    /// Repräsentiert einen Spieler-Charakter.
    /// </summary>
    internal class Player : Character, IAttackable, IAttacker, IInteractor, IInventory
    {
        private List<Item> inventory;

        /// <summary>
        /// Maximale Anzahl Trefferpunkte im gesunden Zustand.
        /// </summary>
        public int MaxHitpoints { get; set; }

        /// <summary>
        /// Anzahl verfügbarer Trefferpunkte.
        /// </summary>
        public int Hitpoints { get; set; }

        /// <summary>
        /// Zeigt an, ob der Spieler noch in einem Portal steht.
        /// </summary>
        public bool InPortal { get; set; }

        /// <summary>
        /// Intern geführte Liste aller angreifbaren Elemente in der Nähe.
        /// </summary>
        public ICollection<Item> AttackableItems { get; private set; }

        /// <summary>
        /// Angriffsradius in dem Schaden ausgeteilt wird.
        /// </summary>
        public float AttackRange { get; set; }

        /// <summary>
        /// Schaden der pro Angriff verursacht wird.
        /// </summary>
        public int AttackValue { get; set; }

        /// <summary>
        /// Gibt die Zeitspanne an, die der Character zur Erholung von einem Schlag benötigt.
        /// </summary>
        public TimeSpan TotalRecovery { get; set; }

        /// <summary>
        /// Gibt die noch verbleibende Erholungszeit an, bevor erneut geschlagen werden kann.
        /// </summary>
        public TimeSpan Recovery { get; set; }

        /// <summary>
        /// Interne auflistung aller Items im Interaktionsradius.
        /// </summary>
        public ICollection<Item> InteractableItems { get; private set; }

        /// <summary>
        /// Interaktionsradius in dem interagiert werden kann.
        /// </summary>
        public float InteractionRange { get; set; }

        /// <summary>
        /// Listet die Items im Inventar auf.
        /// </summary>
        public ICollection<Item> Inventory { get { return inventory; } }

        /// <summary>
        /// Aufruf bei ankommenden Treffern.
        /// </summary>
        public Action<RheinwerkGame, IAttacker, IAttackable> OnHit { get; set; }

        public Player()
        {
            inventory = new List<Item>();
            AttackableItems = new List<Item>();
            InteractableItems = new List<Item>();
            Fixed = false;
            MaxHitpoints = 4;
            Hitpoints = 4;
            AttackRange = 1f;
            AttackValue = 1;
            TotalRecovery = TimeSpan.FromSeconds(0.3);
            InteractionRange = 0.8f;
            Texture = "char.png";
            Name = "Player";
            Icon = "charicon.png";
        }
    }
}

