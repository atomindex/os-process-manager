using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace os_lab2 {
    public partial class MainForm : Form {

        private bool opened;
        private ProcessManager activeManager;

        private FCFS fcfs;
        private RR rr;
        private CA ca;



        public MainForm() {
            InitializeComponent();
        }



        //Создание менеджеров процессов
        private void create(int[][] dataList) {
            //Если менеджеры уже созданы, отвязываем их от отображения
            if (opened) {
                fcfs.Unbind();
                rr.Unbind();
                ca.Unbind();
            }

            opened = true;

            //Создаем списки процессов
            List<Process> fcfsProcesses = new List<Process>();
            List<Process> rrProcesses = new List<Process>();
            List<Process> caProcesses = new List<Process>();

            for (int i = 0; i < dataList.Length; i++) {
                int[] data = dataList[i];
                fcfsProcesses.Add(new Process(i + 1, data[0], data[1], data[2]));
                rrProcesses.Add(new Process(i + 1, data[0], data[1], data[2]));
                caProcesses.Add(new Process(i + 1, data[0], data[1], data[2]));
            }

            //Задаем координаты процессам
            ProcessManager.LayoutProcesses(fcfsProcesses);
            ProcessManager.LayoutProcesses(rrProcesses);
            ProcessManager.LayoutProcesses(caProcesses);

            //Создаем менеджеры процессов
            fcfs = new FCFS(fcfsProcesses, pbFCFS);
            rr = new RR(rrProcesses, pbRR);
            ca = new CA(caProcesses, pbCA);

            //Добавляем событие завершения
            fcfs.AddEndEvent(processManager_End);
            rr.AddEndEvent(processManager_End);
            ca.AddEndEvent(processManager_End);

            //Усьанавливаем скорость
            setSpeed(tbSpeed.Value);
        }

        //Устанавливает скорость все менеджерам
        private void setSpeed(int value) {
            int speed = (int)(1000 - 700 * (value / 10.0));
            fcfs.SetSpeed(speed);
            rr.SetSpeed(speed);
            ca.SetSpeed(speed);
        }

        //Событие завершения всех менеджеров
        private void processManager_End(object sender, EventArgs e) {
            ProcessManager pm = sender as ProcessManager;
            if (pm.IsSelected()) {
                rtbConsole.Text = pm.GetLogs();
            }
        }



        //Событие клика по кнопке загрузки файла
        private void btnLoadFile_Click(object sender, EventArgs e) {
            if (ofd.ShowDialog() != DialogResult.OK) {
                return;
            }

            List<int[]> dataList;
            StreamReader sr = null;

            try {
                sr = new StreamReader(ofd.OpenFile());
                dataList = new List<int[]>();

                while (!sr.EndOfStream) {
                    string s = sr.ReadLine();
                    string[] values = s.Split(
                        new char[] { ' ' }, 3, StringSplitOptions.RemoveEmptyEntries
                    );

                    if (values.Length == 0) {
                        continue;
                    }

                    int startTime = int.Parse(values[0]);
                    int duration = int.Parse(values[1]);
                    int type = int.Parse(values[2]);

                    if (startTime < 0 || type < 0) {
                        sr.Close();
                        MessageBox.Show("Время старта и тип всех процессов должны быть больше нуля", "Ошибка чтения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (duration < 1) {
                        sr.Close();
                        MessageBox.Show("Длительность всех процессов должна быть больше нуля", "Ошибка чтения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    dataList.Add(new int[] { startTime, duration, type });
                }
            } catch (Exception exc) {
                sr.Close();
                MessageBox.Show("При чтении файла произошла ошибка", "Ошибка чтения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dataList.Count == 0) {
                sr.Close();
                MessageBox.Show("Файл пуст", "Ошибка чтения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            sr.Close();

            create(dataList.ToArray());
            btnStart.Enabled = true;
            tbSpeed.Enabled = true;
            pnlConsole.Visible = true;
            rtbConsole.Text = "";
        }

        //Событие клика по кнопке запуска менеджеров
        private void btnStart_Click(object sender, EventArgs e) {
            foreach (ProcessManager pm in new ProcessManager[] { fcfs, rr, ca }) {
                pm.Start();
                if (pm.IsSelected()) {
                    rtbConsole.Text = pm.GetLogs();
                }
            }
        }

        //Событие изменения скорости менеджеров
        private void tbSpeed_Scroll(object sender, EventArgs e) {
            setSpeed(tbSpeed.Value);
        }



        //Событие клика по отображению
        private void view_Click(object sender, EventArgs e) {
            ProcessManager pm = (ProcessManager)(sender as Control).Tag;

            if (pm == null) {
                return;
            }

            if (activeManager != null) {
                activeManager.SetSelected(false);
            }

            activeManager = pm;
            activeManager.SetSelected(true);
            rtbConsole.Text = activeManager.GetLogs();
        }



        //Событие изменения размера формы
        private void MainForm_Resize(object sender, EventArgs e) {
            pbFCFS.Invalidate();
            pbRR.Invalidate();
            pbCA.Invalidate();
        }

        //Событие отрисовки информационной панели
        private void pnlInfo_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            Pen darkPen = new Pen(new SolidBrush(Color.FromArgb(30, 0, 0, 0)), 1);

            g.DrawString("Помощь", new Font(pnlInfo.Font, FontStyle.Bold), Brushes.Black, 10, 10);

            //Надпись 1
            g.FillEllipse(AppSettings.SilverBrush, 10, 32, 15, 15);
            g.DrawEllipse(darkPen, 11, 33, 13, 13);

            g.DrawString("Ожидающий процесс", pnlInfo.Font, Brushes.Black, 31, 31);
            g.DrawString("(Время ожидания)", pnlInfo.Font, Brushes.Black, 31, 44);

            //Надпись 2
            g.FillEllipse(AppSettings.OrangeBrush, 10, 67, 15, 15);
            g.DrawEllipse(darkPen, 11, 68, 13, 13);

            g.DrawString("Акивный процесс", pnlInfo.Font, Brushes.Black, 31, 66);
            g.DrawString("(Длительность выполнения)", pnlInfo.Font, Brushes.Black, 31, 79);

            //Надпись 3
            g.FillEllipse(AppSettings.GreenBrush, 10, 102, 15, 15);
            g.DrawEllipse(darkPen, 11, 103, 13, 13);

            g.DrawString("Завершенный процесс", pnlInfo.Font, Brushes.Black, 31, 101);
            g.DrawString("(Время завершения)", pnlInfo.Font, Brushes.Black, 31, 114);

            //Copyright
            g.DrawLine(Pens.Silver, 10, 142, pnlInfo.Width - 10, 142);
            g.DrawString("Егоров Евгений © 2016 год", pnlInfo.Font, AppSettings.BlackBrush, 10, 155);
        }
    }
}
