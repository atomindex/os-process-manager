using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace os_lab2 {
    public abstract class ProcessManager {
        //LOGIC
        protected Timer timer;                  //Таймер выполнения
        protected string name;                  //Заголовок менеджера

        protected int currentTime;              //Текущее время
        protected List<Process> processes;      //Список процессов
        protected Process currentProcess;       //Текущий процесс
        protected int doneProcessesCount;       //Количество выполненных процессов
        protected int speed;                    //Скорость выполнения
        protected bool ended;                   //Триггер окончания выполнения

        protected StringBuilder logs;           //Логи выполнения
        protected EventHandler onEnd;           //Событие окончания выполнения

        //INTERFACE
        private static int cellSize;            //Размер клеток
        private static Pen netPen;              //Цвет клеток
        private static Pen activePen;           //Цвет выделения
        private static Font titleFont;          //Шрифт заголовка
        protected PictureBox view;              //Отображение
        protected bool selected;                //Триггер выделения



        //LOGIC



        //Конструктор
        static ProcessManager() {
            netPen = new Pen(Color.FromArgb(255, 230, 230, 230), 1);
            activePen = new Pen(AppSettings.OrangeBrush, 4);
            titleFont = new Font(FontFamily.GenericSansSerif, 9, FontStyle.Bold);
            cellSize = 10;
        }

        //Конструктор
        public ProcessManager(List<Process> processes, PictureBox view) {
            this.processes = processes;

            this.view = view;
            view.Paint += view_Paint;
            view.Tag = this;
            view.Invalidate();

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += timer_Tick;

            speed = 1000;
            logs = new StringBuilder();
        }

        //Событие тика таймера
        protected abstract void timer_Tick(object sender, EventArgs e);

        //Возвращает интервал с учетом скорости
        protected int getInterval(int ms) {
            return (int)(ms / 1000.0 * speed);
        }

        //Запускает процессы
        public virtual void Start() {
            if (IsProcessing() || processes.Count == 0) {
                return;
            }

            timer.Stop();

            foreach (Process process in processes) {
                process.Reset();
            }

            currentTime = 0;
            currentProcess = null;
            doneProcessesCount = 0;
            ended = false;
            logs.Clear();

            timer.Start();
            timer_Tick(null, null);
        }

        //Возвращает логи
        public string GetLogs() {
            if (IsProcessing()) {
                return "Обрабатывается...";
            }

            if (!ended) {
                return "Запустите процессы для получения данных";
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(name);

            sb.Append("\n\nВремя выполнения: ");
            sb.Append((currentTime/1000).ToString());
            sb.Append(" с\n");

            sb.Append("Среднее время выполнения процессов: ");
            sb.Append(GetAverageRuntime().ToString());
            sb.Append(" с\n");

            sb.Append("Среднее время ожидания процессов: ");
            sb.Append(GetAverageWait().ToString());
            sb.Append(" с\n\n");

            sb.Append("Логи:\n");
            sb.Append(logs.ToString());

            return sb.ToString();
        }

        //Возвращает true если процессы запущены
        public bool IsProcessing() {
            return timer.Enabled;
        }

        //Возвращает название алгоритма
        public string GetName() {
            return name;
        }

        //Возвращает среднее время выполнения
        public double GetAverageRuntime() {
            if (IsProcessing())
                return -1;

            int sum = 0;
            for (int i = 0; i < processes.Count; i++) {
                sum += processes[i].GetRuntime();
            }

            return (double)sum / processes.Count / 1000;
        }

        //Возвращает среднее время ожидания
        public double GetAverageWait() {
            if (IsProcessing())
                return -1;

            int sum = 0;
            for (int i = 0; i < processes.Count; i++) {
                sum += processes[i].GetWaitTime();
            }

            return (double)sum / processes.Count / 1000;
        }

        //Устанавливает скорость
        public virtual void SetSpeed(int ms) {
            speed = ms;
        }

        //Добавляет событие на завершение
        public void AddEndEvent(EventHandler e) {
            onEnd += e;
        }

        //Отвязка от отображения
        public void Unbind() {
            timer.Stop();

            view.Paint -= view_Paint;
            view.Tag = null;
        }



        //INTERFACE


       
        //Задает координаты процессам
        public static void LayoutProcesses(List<Process> processes) {
            double step = 2 * Math.PI / processes.Count;

            for (int i = 0; i < processes.Count; i++) {
                double x = 50 + 50 * Math.Sin(step * i);
                double y = 50 + 50 * Math.Cos(step * i);

                processes[i].SetPosition(x, y);
            }
        }

        //Отрисовывает процессы
        private void view_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.FillRectangle(Brushes.White, 0, 0, view.Width, view.Height);

            int centerX = view.Width / 2;
            int centerY = view.Height / 2;

            //Рисуем сетку
            for (int x = cellSize; x < centerX; x += cellSize) {
                g.DrawLine(netPen, new Point(centerX - x, 5), new Point(centerX - x, view.Height - 5));
                g.DrawLine(netPen, new Point(centerX + x, 5), new Point(centerX + x, view.Height - 5));
            }

            for (int y = cellSize; y < centerY; y += cellSize) {
                g.DrawLine(netPen, new Point(5, centerY - y), new Point(view.Width - 5, centerY - y));
                g.DrawLine(netPen, new Point(5, centerY + y), new Point(view.Width - 5, centerY + y));
            }

            g.DrawLine(netPen, new Point(centerX, 5), new Point(centerX, view.Height - 5));
            g.DrawLine(netPen, new Point(5, centerY), new Point(view.Width - 5, centerY));


            if (selected) {
                g.DrawRectangle(activePen, 0, 0, view.Width-1, view.Height-1);
            }

            g.DrawString(name, titleFont, Brushes.Black, 10, 10);

            //Рисуем процессы
            foreach (Process process in processes) {
                process.Render(e.Graphics, view.Width, view.Height);
            }
        }

        //Устанавливает выделение
        public void SetSelected(bool value) {
            selected = value;
            view.Invalidate();
        }

        //Возвращает true если уановлено выделение
        public bool IsSelected() {
            return selected;
        }
    }
}
