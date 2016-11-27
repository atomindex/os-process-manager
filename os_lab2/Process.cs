using System.Drawing;

namespace os_lab2 {
    public class Process {
        //LOGIC
        private Status status;

        private int index;                  //Индекс процесса
        private int startTime;              //Время запуска
        private int duration;               //Длительность выполнения
        private int type;                   //Тип процесса

        private int lastUpdateTime;         //Время последнего обновления

        private int currentDuration;        //Текущая длительность выполнения
        private int waitTime;               //Текущее время ожидания
        private int realSatrtTime;          //Реальное время запуска
        private int endTime;                //Время окончания процесса

        //INTERFACE
        private double left;                                //Положение по x
        private double top;                                 //Положение по y
        private static StringFormat alignCenterFormat;      //Выравнивание текста по центру
        private static Font font;                           //Шрифт для времени
        private static Font indexFont;                      //Шрифт для индекса



        //LOGIC



        //Конструктор
        static Process() {
            alignCenterFormat = new StringFormat();
            alignCenterFormat.Alignment = StringAlignment.Center;
            alignCenterFormat.LineAlignment = StringAlignment.Center;

            font = new Font(FontFamily.GenericSansSerif, 10);
            indexFont = new Font(FontFamily.GenericSansSerif, 7);
        }

        //Конструктор
        public Process(int index, int startTime, int duration, int type) {
            this.index = index;
            this.startTime = startTime * 1000;
            this.duration = duration * 1000;
            this.type = type;

            status = Status.Blocked;
        }



        //Обновляет данные процесса
        public void Update(int globalTime) {
            switch (status) {
                case Status.Done:
                    return;
                case Status.Blocked:
                    if (startTime <= globalTime) {
                        waitTime += globalTime - lastUpdateTime;
                    }
                    break;
                case Status.Active:
                    if (currentDuration == 0) {
                        realSatrtTime = lastUpdateTime;
                    }

                    currentDuration += globalTime - lastUpdateTime;

                    if (currentDuration == duration) {
                        status = Status.Done;
                        endTime = globalTime;
                    }
                    break;
            }

            lastUpdateTime = globalTime;
        }

        //Возвращает индекс процесса
        public int GetIndex() {
            return index;
        }

        //Возвращает время запуска процесса
        public int GetStartTime() {
            return startTime;
        }

        //Возвращает длительность процесса
        public int GetDuration() {
            return duration;
        }

        //Возвращает оставшуюся длительность процесса
        public int GetRestDuration() {
            return duration - currentDuration;
        }

        //Возвращает время выполнения
        public int GetRuntime() {
            return status == Status.Done ? endTime - realSatrtTime : -1;
        }

        //Возвращает время ожидания
        public int GetWaitTime() {
            return status == Status.Done ? waitTime : -1;
        }

        //Возвращает true если процесс закончен
        public bool IsDone() {
            return status == Status.Done;
        }



        //Устанавливает статус процесса как Активный
        public void SetActive(bool active) {
            status = active ? Status.Active : Status.Blocked;
        }

        //Сбрасывает процесс
        public void Reset() {
            lastUpdateTime = 0;
            currentDuration = 0;
            waitTime = 0;
            endTime = 0;

            status = Status.Blocked;
        }



        //INTERFACE



        //Устанавливает координаты процесса
        public void SetPosition(double left, double top) {
            this.left = left;
            this.top = top;
        }

        //Отрисовывает процесс
        public void Render(Graphics g, int viewWidth, int viewHeight) {
            double x = (viewWidth - 150) / 100.0 * left;
            double y = (viewHeight - 120) / 100.0 * top;

            Brush b = null;
            Rectangle rect = new Rectangle((int)(x - 20 + 75), (int)(y - 20 + 60), 40, 40);
            Rectangle indexRect = new Rectangle((int)(x - 20 + 72), (int)(y - 20 + 60 + 40 - 12), 17, 12);
            string s = "";

            switch (status) {
                case Status.Blocked:
                    b = AppSettings.SilverBrush;
                    s = (waitTime / 1000.0).ToString();
                    break;
                case Status.Active:
                    b = AppSettings.OrangeBrush;
                    s = (currentDuration / 1000.0).ToString();
                    break;
                case Status.Done:
                    b = AppSettings.GreenBrush;
                    s = (endTime / 1000.0).ToString();
                    break;
            }

            g.FillEllipse(b, rect);
            g.DrawString(s, font, Brushes.White, rect, alignCenterFormat);

            g.FillRectangle(AppSettings.BlackBrush, indexRect);
            g.DrawString(index.ToString(), indexFont, Brushes.White, indexRect, alignCenterFormat);
        }
    }
}
