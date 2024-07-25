namespace rts_2D
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Start = new System.Windows.Forms.Button();
            this.txt_Cibo = new System.Windows.Forms.TextBox();
            this.txt_Legno = new System.Windows.Forms.TextBox();
            this.txt_Pietra = new System.Windows.Forms.TextBox();
            this.txt_Ferro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Oro = new System.Windows.Forms.TextBox();
            this.txt_Strutture = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Esercito = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_Spade = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Lance = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_Scudi = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_Archi = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_Armature = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btn_Recluta_Truppe = new System.Windows.Forms.Button();
            this.txt_Catapulta = new System.Windows.Forms.TextBox();
            this.txt_Arciere = new System.Windows.Forms.TextBox();
            this.txt_Guerriero = new System.Windows.Forms.TextBox();
            this.txt_Cava = new System.Windows.Forms.TextBox();
            this.txt_Segheria = new System.Windows.Forms.TextBox();
            this.txt_Fattoria = new System.Windows.Forms.TextBox();
            this.btn_Costruisci_Strutture = new System.Windows.Forms.Button();
            this.lbl_CavaPietra = new System.Windows.Forms.Label();
            this.lbl_Segheria = new System.Windows.Forms.Label();
            this.lbl_Fattoria = new System.Windows.Forms.Label();
            this.txt_Miniera_Oro = new System.Windows.Forms.TextBox();
            this.txt_Miniera_Ferro = new System.Windows.Forms.TextBox();
            this.lbl_MinieraOro = new System.Windows.Forms.Label();
            this.lbl_MinieraFerro = new System.Windows.Forms.Label();
            this.txt_Log = new System.Windows.Forms.TextBox();
            this.txt_Lancieri = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txt_Tempo_Costruzione = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txt_Tempo_Reclutamento = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_Popolazione = new System.Windows.Forms.TextBox();
            this.txt_Cose = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_Produzione_Popolazione = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txt_Produzione_Oro = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txt_Produzione_Ferro = new System.Windows.Forms.TextBox();
            this.txt_Produzione_Pietra = new System.Windows.Forms.TextBox();
            this.txt_Produzione_Legno = new System.Windows.Forms.TextBox();
            this.txt_Produzione_Cibo = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_Invasioni = new System.Windows.Forms.Button();
            this.txt_Esercito_Invasore = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txt_Timer_Invasione = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(402, 18);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(75, 32);
            this.btn_Start.TabIndex = 0;
            this.btn_Start.Text = "Gioca";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // txt_Cibo
            // 
            this.txt_Cibo.Location = new System.Drawing.Point(12, 30);
            this.txt_Cibo.Name = "txt_Cibo";
            this.txt_Cibo.ReadOnly = true;
            this.txt_Cibo.Size = new System.Drawing.Size(59, 20);
            this.txt_Cibo.TabIndex = 1;
            this.txt_Cibo.Text = "0";
            // 
            // txt_Legno
            // 
            this.txt_Legno.Location = new System.Drawing.Point(77, 30);
            this.txt_Legno.Name = "txt_Legno";
            this.txt_Legno.ReadOnly = true;
            this.txt_Legno.Size = new System.Drawing.Size(59, 20);
            this.txt_Legno.TabIndex = 2;
            this.txt_Legno.Text = "0";
            // 
            // txt_Pietra
            // 
            this.txt_Pietra.Location = new System.Drawing.Point(142, 30);
            this.txt_Pietra.Name = "txt_Pietra";
            this.txt_Pietra.ReadOnly = true;
            this.txt_Pietra.Size = new System.Drawing.Size(59, 20);
            this.txt_Pietra.TabIndex = 3;
            this.txt_Pietra.Text = "0";
            // 
            // txt_Ferro
            // 
            this.txt_Ferro.Location = new System.Drawing.Point(207, 30);
            this.txt_Ferro.Name = "txt_Ferro";
            this.txt_Ferro.ReadOnly = true;
            this.txt_Ferro.Size = new System.Drawing.Size(59, 20);
            this.txt_Ferro.TabIndex = 4;
            this.txt_Ferro.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Cibo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Legno";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ferro";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(149, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Pietra";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(281, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Oro";
            // 
            // txt_Oro
            // 
            this.txt_Oro.Location = new System.Drawing.Point(272, 30);
            this.txt_Oro.Name = "txt_Oro";
            this.txt_Oro.ReadOnly = true;
            this.txt_Oro.Size = new System.Drawing.Size(59, 20);
            this.txt_Oro.TabIndex = 9;
            this.txt_Oro.Text = "0";
            // 
            // txt_Strutture
            // 
            this.txt_Strutture.Location = new System.Drawing.Point(486, 34);
            this.txt_Strutture.Multiline = true;
            this.txt_Strutture.Name = "txt_Strutture";
            this.txt_Strutture.ReadOnly = true;
            this.txt_Strutture.Size = new System.Drawing.Size(127, 155);
            this.txt_Strutture.TabIndex = 11;
            this.txt_Strutture.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(483, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Strutture";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(616, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Esercito";
            // 
            // txt_Esercito
            // 
            this.txt_Esercito.Location = new System.Drawing.Point(619, 34);
            this.txt_Esercito.Multiline = true;
            this.txt_Esercito.Name = "txt_Esercito";
            this.txt_Esercito.ReadOnly = true;
            this.txt_Esercito.Size = new System.Drawing.Size(127, 155);
            this.txt_Esercito.TabIndex = 13;
            this.txt_Esercito.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 68);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "Spade";
            // 
            // txt_Spade
            // 
            this.txt_Spade.Location = new System.Drawing.Point(58, 65);
            this.txt_Spade.Name = "txt_Spade";
            this.txt_Spade.ReadOnly = true;
            this.txt_Spade.Size = new System.Drawing.Size(59, 20);
            this.txt_Spade.TabIndex = 15;
            this.txt_Spade.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Lance";
            // 
            // txt_Lance
            // 
            this.txt_Lance.Location = new System.Drawing.Point(58, 91);
            this.txt_Lance.Name = "txt_Lance";
            this.txt_Lance.ReadOnly = true;
            this.txt_Lance.Size = new System.Drawing.Size(59, 20);
            this.txt_Lance.TabIndex = 20;
            this.txt_Lance.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Scudi";
            // 
            // txt_Scudi
            // 
            this.txt_Scudi.Location = new System.Drawing.Point(58, 143);
            this.txt_Scudi.Name = "txt_Scudi";
            this.txt_Scudi.ReadOnly = true;
            this.txt_Scudi.Size = new System.Drawing.Size(59, 20);
            this.txt_Scudi.TabIndex = 24;
            this.txt_Scudi.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 120);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Archi";
            // 
            // txt_Archi
            // 
            this.txt_Archi.Location = new System.Drawing.Point(58, 117);
            this.txt_Archi.Name = "txt_Archi";
            this.txt_Archi.ReadOnly = true;
            this.txt_Archi.Size = new System.Drawing.Size(59, 20);
            this.txt_Archi.TabIndex = 22;
            this.txt_Archi.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 172);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 13);
            this.label16.TabIndex = 29;
            this.label16.Text = "Armature";
            // 
            // txt_Armature
            // 
            this.txt_Armature.Location = new System.Drawing.Point(58, 169);
            this.txt_Armature.Name = "txt_Armature";
            this.txt_Armature.ReadOnly = true;
            this.txt_Armature.Size = new System.Drawing.Size(59, 20);
            this.txt_Armature.TabIndex = 28;
            this.txt_Armature.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(4, 108);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 13);
            this.label14.TabIndex = 35;
            this.label14.Text = "Catapulta";
            this.label14.MouseHover += new System.EventHandler(this.label14_MouseHover);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(13, 82);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 13);
            this.label15.TabIndex = 33;
            this.label15.Text = "Arciere";
            this.label15.MouseHover += new System.EventHandler(this.label15_MouseHover);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 30);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(50, 13);
            this.label17.TabIndex = 31;
            this.label17.Text = "Guerriero";
            this.label17.MouseHover += new System.EventHandler(this.label17_MouseHover);
            // 
            // btn_Recluta_Truppe
            // 
            this.btn_Recluta_Truppe.Location = new System.Drawing.Point(146, 19);
            this.btn_Recluta_Truppe.Name = "btn_Recluta_Truppe";
            this.btn_Recluta_Truppe.Size = new System.Drawing.Size(67, 24);
            this.btn_Recluta_Truppe.TabIndex = 37;
            this.btn_Recluta_Truppe.Text = "Recluta";
            this.btn_Recluta_Truppe.UseVisualStyleBackColor = true;
            this.btn_Recluta_Truppe.Click += new System.EventHandler(this.btn_Recluta_Truppe_Click);
            // 
            // txt_Catapulta
            // 
            this.txt_Catapulta.Location = new System.Drawing.Point(65, 105);
            this.txt_Catapulta.Name = "txt_Catapulta";
            this.txt_Catapulta.Size = new System.Drawing.Size(49, 20);
            this.txt_Catapulta.TabIndex = 41;
            this.txt_Catapulta.Text = "0";
            // 
            // txt_Arciere
            // 
            this.txt_Arciere.Location = new System.Drawing.Point(65, 79);
            this.txt_Arciere.Name = "txt_Arciere";
            this.txt_Arciere.Size = new System.Drawing.Size(49, 20);
            this.txt_Arciere.TabIndex = 40;
            this.txt_Arciere.Text = "0";
            // 
            // txt_Guerriero
            // 
            this.txt_Guerriero.Location = new System.Drawing.Point(65, 27);
            this.txt_Guerriero.Name = "txt_Guerriero";
            this.txt_Guerriero.Size = new System.Drawing.Size(49, 20);
            this.txt_Guerriero.TabIndex = 39;
            this.txt_Guerriero.Text = "0";
            // 
            // txt_Cava
            // 
            this.txt_Cava.Location = new System.Drawing.Point(187, 19);
            this.txt_Cava.Name = "txt_Cava";
            this.txt_Cava.Size = new System.Drawing.Size(49, 20);
            this.txt_Cava.TabIndex = 64;
            this.txt_Cava.Text = "0";
            // 
            // txt_Segheria
            // 
            this.txt_Segheria.Location = new System.Drawing.Point(57, 45);
            this.txt_Segheria.Name = "txt_Segheria";
            this.txt_Segheria.Size = new System.Drawing.Size(49, 20);
            this.txt_Segheria.TabIndex = 63;
            this.txt_Segheria.Text = "0";
            // 
            // txt_Fattoria
            // 
            this.txt_Fattoria.Location = new System.Drawing.Point(57, 19);
            this.txt_Fattoria.Name = "txt_Fattoria";
            this.txt_Fattoria.Size = new System.Drawing.Size(49, 20);
            this.txt_Fattoria.TabIndex = 62;
            this.txt_Fattoria.Text = "0";
            // 
            // btn_Costruisci_Strutture
            // 
            this.btn_Costruisci_Strutture.Location = new System.Drawing.Point(15, 74);
            this.btn_Costruisci_Strutture.Name = "btn_Costruisci_Strutture";
            this.btn_Costruisci_Strutture.Size = new System.Drawing.Size(86, 30);
            this.btn_Costruisci_Strutture.TabIndex = 61;
            this.btn_Costruisci_Strutture.Text = "Costruisci";
            this.btn_Costruisci_Strutture.UseVisualStyleBackColor = true;
            this.btn_Costruisci_Strutture.Click += new System.EventHandler(this.btn_Costruisci_Strutture_Click);
            // 
            // lbl_CavaPietra
            // 
            this.lbl_CavaPietra.AutoSize = true;
            this.lbl_CavaPietra.Location = new System.Drawing.Point(114, 22);
            this.lbl_CavaPietra.Name = "lbl_CavaPietra";
            this.lbl_CavaPietra.Size = new System.Drawing.Size(62, 13);
            this.lbl_CavaPietra.TabIndex = 58;
            this.lbl_CavaPietra.Text = "Cava Pietra";
            this.lbl_CavaPietra.MouseHover += new System.EventHandler(this.lbl_CavaPietra_MouseHover);
            // 
            // lbl_Segheria
            // 
            this.lbl_Segheria.AutoSize = true;
            this.lbl_Segheria.Location = new System.Drawing.Point(2, 48);
            this.lbl_Segheria.Name = "lbl_Segheria";
            this.lbl_Segheria.Size = new System.Drawing.Size(49, 13);
            this.lbl_Segheria.TabIndex = 57;
            this.lbl_Segheria.Text = "Segheria";
            this.lbl_Segheria.MouseHover += new System.EventHandler(this.lbl_Segheria_MouseHover);
            // 
            // lbl_Fattoria
            // 
            this.lbl_Fattoria.AutoSize = true;
            this.lbl_Fattoria.Location = new System.Drawing.Point(9, 22);
            this.lbl_Fattoria.Name = "lbl_Fattoria";
            this.lbl_Fattoria.Size = new System.Drawing.Size(42, 13);
            this.lbl_Fattoria.TabIndex = 56;
            this.lbl_Fattoria.Text = "Fattoria";
            this.lbl_Fattoria.MouseHover += new System.EventHandler(this.lbl_Fattoria_MouseHover);
            // 
            // txt_Miniera_Oro
            // 
            this.txt_Miniera_Oro.Location = new System.Drawing.Point(187, 71);
            this.txt_Miniera_Oro.Name = "txt_Miniera_Oro";
            this.txt_Miniera_Oro.Size = new System.Drawing.Size(49, 20);
            this.txt_Miniera_Oro.TabIndex = 70;
            this.txt_Miniera_Oro.Text = "0";
            // 
            // txt_Miniera_Ferro
            // 
            this.txt_Miniera_Ferro.Location = new System.Drawing.Point(187, 45);
            this.txt_Miniera_Ferro.Name = "txt_Miniera_Ferro";
            this.txt_Miniera_Ferro.Size = new System.Drawing.Size(49, 20);
            this.txt_Miniera_Ferro.TabIndex = 69;
            this.txt_Miniera_Ferro.Text = "0";
            // 
            // lbl_MinieraOro
            // 
            this.lbl_MinieraOro.AutoSize = true;
            this.lbl_MinieraOro.Location = new System.Drawing.Point(114, 74);
            this.lbl_MinieraOro.Name = "lbl_MinieraOro";
            this.lbl_MinieraOro.Size = new System.Drawing.Size(61, 13);
            this.lbl_MinieraOro.TabIndex = 66;
            this.lbl_MinieraOro.Text = "Miniera Oro";
            this.lbl_MinieraOro.MouseHover += new System.EventHandler(this.lbl_MinieraOro_MouseHover);
            // 
            // lbl_MinieraFerro
            // 
            this.lbl_MinieraFerro.AutoSize = true;
            this.lbl_MinieraFerro.Location = new System.Drawing.Point(114, 48);
            this.lbl_MinieraFerro.Name = "lbl_MinieraFerro";
            this.lbl_MinieraFerro.Size = new System.Drawing.Size(68, 13);
            this.lbl_MinieraFerro.TabIndex = 65;
            this.lbl_MinieraFerro.Text = "Miniera Ferro";
            this.lbl_MinieraFerro.MouseHover += new System.EventHandler(this.lbl_MinieraFerro_MouseHover);
            // 
            // txt_Log
            // 
            this.txt_Log.Location = new System.Drawing.Point(123, 56);
            this.txt_Log.Multiline = true;
            this.txt_Log.Name = "txt_Log";
            this.txt_Log.ReadOnly = true;
            this.txt_Log.Size = new System.Drawing.Size(143, 133);
            this.txt_Log.TabIndex = 79;
            // 
            // txt_Lancieri
            // 
            this.txt_Lancieri.Location = new System.Drawing.Point(65, 53);
            this.txt_Lancieri.Name = "txt_Lancieri";
            this.txt_Lancieri.Size = new System.Drawing.Size(49, 20);
            this.txt_Lancieri.TabIndex = 81;
            this.txt_Lancieri.Text = "0";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(9, 56);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(44, 13);
            this.label23.TabIndex = 80;
            this.label23.Text = "Lancieri";
            this.label23.MouseHover += new System.EventHandler(this.label23_MouseHover);
            // 
            // txt_Tempo_Costruzione
            // 
            this.txt_Tempo_Costruzione.Location = new System.Drawing.Point(116, 104);
            this.txt_Tempo_Costruzione.Name = "txt_Tempo_Costruzione";
            this.txt_Tempo_Costruzione.Size = new System.Drawing.Size(64, 20);
            this.txt_Tempo_Costruzione.TabIndex = 82;
            this.txt_Tempo_Costruzione.Text = "0";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(12, 107);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(98, 13);
            this.label24.TabIndex = 83;
            this.label24.Text = "Tempo Costruzione";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(123, 50);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(109, 13);
            this.label25.TabIndex = 85;
            this.label25.Text = "Tempo Reclutamento";
            // 
            // txt_Tempo_Reclutamento
            // 
            this.txt_Tempo_Reclutamento.Location = new System.Drawing.Point(146, 73);
            this.txt_Tempo_Reclutamento.Name = "txt_Tempo_Reclutamento";
            this.txt_Tempo_Reclutamento.Size = new System.Drawing.Size(64, 20);
            this.txt_Tempo_Reclutamento.TabIndex = 84;
            this.txt_Tempo_Reclutamento.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.lbl_Fattoria);
            this.groupBox1.Controls.Add(this.lbl_Segheria);
            this.groupBox1.Controls.Add(this.lbl_CavaPietra);
            this.groupBox1.Controls.Add(this.txt_Tempo_Costruzione);
            this.groupBox1.Controls.Add(this.btn_Costruisci_Strutture);
            this.groupBox1.Controls.Add(this.txt_Fattoria);
            this.groupBox1.Controls.Add(this.txt_Segheria);
            this.groupBox1.Controls.Add(this.txt_Cava);
            this.groupBox1.Controls.Add(this.txt_Miniera_Oro);
            this.groupBox1.Controls.Add(this.lbl_MinieraFerro);
            this.groupBox1.Controls.Add(this.txt_Miniera_Ferro);
            this.groupBox1.Controls.Add(this.lbl_MinieraOro);
            this.groupBox1.Location = new System.Drawing.Point(6, 204);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 134);
            this.groupBox1.TabIndex = 86;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Costruzione Strutture";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txt_Tempo_Reclutamento);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.btn_Recluta_Truppe);
            this.groupBox2.Controls.Add(this.txt_Lancieri);
            this.groupBox2.Controls.Add(this.txt_Guerriero);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.txt_Arciere);
            this.groupBox2.Controls.Add(this.txt_Catapulta);
            this.groupBox2.Location = new System.Drawing.Point(263, 204);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(234, 134);
            this.groupBox2.TabIndex = 87;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reclutamento";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(334, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 89;
            this.label11.Text = "Popolazione";
            // 
            // txt_Popolazione
            // 
            this.txt_Popolazione.Location = new System.Drawing.Point(337, 30);
            this.txt_Popolazione.Name = "txt_Popolazione";
            this.txt_Popolazione.ReadOnly = true;
            this.txt_Popolazione.Size = new System.Drawing.Size(59, 20);
            this.txt_Popolazione.TabIndex = 88;
            this.txt_Popolazione.Text = "0";
            // 
            // txt_Cose
            // 
            this.txt_Cose.Location = new System.Drawing.Point(272, 56);
            this.txt_Cose.Multiline = true;
            this.txt_Cose.Name = "txt_Cose";
            this.txt_Cose.ReadOnly = true;
            this.txt_Cose.Size = new System.Drawing.Size(208, 133);
            this.txt_Cose.TabIndex = 90;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(322, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 13);
            this.label13.TabIndex = 102;
            this.label13.Text = "Popolazione";
            // 
            // txt_Produzione_Popolazione
            // 
            this.txt_Produzione_Popolazione.Location = new System.Drawing.Point(335, 32);
            this.txt_Produzione_Popolazione.Name = "txt_Produzione_Popolazione";
            this.txt_Produzione_Popolazione.ReadOnly = true;
            this.txt_Produzione_Popolazione.Size = new System.Drawing.Size(52, 20);
            this.txt_Produzione_Popolazione.TabIndex = 101;
            this.txt_Produzione_Popolazione.Text = "0";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(269, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(24, 13);
            this.label18.TabIndex = 100;
            this.label18.Text = "Oro";
            // 
            // txt_Produzione_Oro
            // 
            this.txt_Produzione_Oro.Location = new System.Drawing.Point(270, 32);
            this.txt_Produzione_Oro.Name = "txt_Produzione_Oro";
            this.txt_Produzione_Oro.ReadOnly = true;
            this.txt_Produzione_Oro.Size = new System.Drawing.Size(52, 20);
            this.txt_Produzione_Oro.TabIndex = 99;
            this.txt_Produzione_Oro.Text = "0";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(204, 16);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(31, 13);
            this.label19.TabIndex = 98;
            this.label19.Text = "Ferro";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(137, 16);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(34, 13);
            this.label20.TabIndex = 97;
            this.label20.Text = "Pietra";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(76, 16);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(37, 13);
            this.label21.TabIndex = 96;
            this.label21.Text = "Legno";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(9, 16);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(28, 13);
            this.label22.TabIndex = 95;
            this.label22.Text = "Cibo";
            // 
            // txt_Produzione_Ferro
            // 
            this.txt_Produzione_Ferro.Location = new System.Drawing.Point(205, 32);
            this.txt_Produzione_Ferro.Name = "txt_Produzione_Ferro";
            this.txt_Produzione_Ferro.ReadOnly = true;
            this.txt_Produzione_Ferro.Size = new System.Drawing.Size(52, 20);
            this.txt_Produzione_Ferro.TabIndex = 94;
            this.txt_Produzione_Ferro.Text = "0";
            // 
            // txt_Produzione_Pietra
            // 
            this.txt_Produzione_Pietra.Location = new System.Drawing.Point(140, 32);
            this.txt_Produzione_Pietra.Name = "txt_Produzione_Pietra";
            this.txt_Produzione_Pietra.ReadOnly = true;
            this.txt_Produzione_Pietra.Size = new System.Drawing.Size(52, 20);
            this.txt_Produzione_Pietra.TabIndex = 93;
            this.txt_Produzione_Pietra.Text = "0";
            // 
            // txt_Produzione_Legno
            // 
            this.txt_Produzione_Legno.Location = new System.Drawing.Point(75, 32);
            this.txt_Produzione_Legno.Name = "txt_Produzione_Legno";
            this.txt_Produzione_Legno.ReadOnly = true;
            this.txt_Produzione_Legno.Size = new System.Drawing.Size(52, 20);
            this.txt_Produzione_Legno.TabIndex = 92;
            this.txt_Produzione_Legno.Text = "0";
            // 
            // txt_Produzione_Cibo
            // 
            this.txt_Produzione_Cibo.Location = new System.Drawing.Point(10, 32);
            this.txt_Produzione_Cibo.Name = "txt_Produzione_Cibo";
            this.txt_Produzione_Cibo.ReadOnly = true;
            this.txt_Produzione_Cibo.Size = new System.Drawing.Size(52, 20);
            this.txt_Produzione_Cibo.TabIndex = 91;
            this.txt_Produzione_Cibo.Text = "0";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txt_Produzione_Cibo);
            this.groupBox3.Controls.Add(this.txt_Produzione_Popolazione);
            this.groupBox3.Controls.Add(this.txt_Produzione_Legno);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.txt_Produzione_Pietra);
            this.groupBox3.Controls.Add(this.txt_Produzione_Oro);
            this.groupBox3.Controls.Add(this.txt_Produzione_Ferro);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Location = new System.Drawing.Point(6, 344);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(393, 62);
            this.groupBox3.TabIndex = 103;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Produzione";
            // 
            // btn_Invasioni
            // 
            this.btn_Invasioni.Location = new System.Drawing.Point(503, 204);
            this.btn_Invasioni.Name = "btn_Invasioni";
            this.btn_Invasioni.Size = new System.Drawing.Size(67, 24);
            this.btn_Invasioni.TabIndex = 104;
            this.btn_Invasioni.Text = "Inviasioni";
            this.btn_Invasioni.UseVisualStyleBackColor = true;
            this.btn_Invasioni.Visible = false;
            this.btn_Invasioni.Click += new System.EventHandler(this.btn_Invasioni_Click);
            // 
            // txt_Esercito_Invasore
            // 
            this.txt_Esercito_Invasore.Location = new System.Drawing.Point(619, 221);
            this.txt_Esercito_Invasore.Multiline = true;
            this.txt_Esercito_Invasore.Name = "txt_Esercito_Invasore";
            this.txt_Esercito_Invasore.ReadOnly = true;
            this.txt_Esercito_Invasore.Size = new System.Drawing.Size(127, 155);
            this.txt_Esercito_Invasore.TabIndex = 105;
            this.txt_Esercito_Invasore.Text = "0";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(616, 205);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(53, 13);
            this.label26.TabIndex = 106;
            this.label26.Text = "Invasione";
            // 
            // txt_Timer_Invasione
            // 
            this.txt_Timer_Invasione.Location = new System.Drawing.Point(679, 198);
            this.txt_Timer_Invasione.Name = "txt_Timer_Invasione";
            this.txt_Timer_Invasione.Size = new System.Drawing.Size(67, 20);
            this.txt_Timer_Invasione.TabIndex = 107;
            this.txt_Timer_Invasione.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 418);
            this.Controls.Add(this.txt_Timer_Invasione);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.txt_Esercito_Invasore);
            this.Controls.Add(this.btn_Invasioni);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txt_Cose);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_Popolazione);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_Log);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txt_Armature);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_Scudi);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_Archi);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_Lance);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txt_Spade);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_Esercito);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_Strutture);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_Oro);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Ferro);
            this.Controls.Add(this.txt_Pietra);
            this.Controls.Add(this.txt_Legno);
            this.Controls.Add(this.txt_Cibo);
            this.Controls.Add(this.btn_Start);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.TextBox txt_Cibo;
        private System.Windows.Forms.TextBox txt_Legno;
        private System.Windows.Forms.TextBox txt_Pietra;
        private System.Windows.Forms.TextBox txt_Ferro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Oro;
        private System.Windows.Forms.TextBox txt_Strutture;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Esercito;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_Spade;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_Lance;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_Scudi;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_Archi;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_Armature;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btn_Recluta_Truppe;
        private System.Windows.Forms.TextBox txt_Catapulta;
        private System.Windows.Forms.TextBox txt_Arciere;
        private System.Windows.Forms.TextBox txt_Guerriero;
        private System.Windows.Forms.TextBox txt_Cava;
        private System.Windows.Forms.TextBox txt_Segheria;
        private System.Windows.Forms.TextBox txt_Fattoria;
        private System.Windows.Forms.Button btn_Costruisci_Strutture;
        private System.Windows.Forms.Label lbl_CavaPietra;
        private System.Windows.Forms.Label lbl_Segheria;
        private System.Windows.Forms.Label lbl_Fattoria;
        private System.Windows.Forms.TextBox txt_Miniera_Oro;
        private System.Windows.Forms.TextBox txt_Miniera_Ferro;
        private System.Windows.Forms.Label lbl_MinieraOro;
        private System.Windows.Forms.Label lbl_MinieraFerro;
        private System.Windows.Forms.TextBox txt_Log;
        private System.Windows.Forms.TextBox txt_Lancieri;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txt_Tempo_Costruzione;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txt_Tempo_Reclutamento;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_Popolazione;
        private System.Windows.Forms.TextBox txt_Cose;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_Produzione_Popolazione;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txt_Produzione_Oro;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txt_Produzione_Ferro;
        private System.Windows.Forms.TextBox txt_Produzione_Pietra;
        private System.Windows.Forms.TextBox txt_Produzione_Legno;
        private System.Windows.Forms.TextBox txt_Produzione_Cibo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_Invasioni;
        private System.Windows.Forms.TextBox txt_Esercito_Invasore;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txt_Timer_Invasione;
    }
}

