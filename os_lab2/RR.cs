using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace os_lab2 {
    public class RR : ProcessManager {

        private int currentProcessIndex;

        private List<Process> sleepProcesses;
        private List<Process> readyProcesses;
        private int interval;



        //Конструктор
        public RR(List<Process> processes, PictureBox view) : base(processes, view) {
            name = "Round Robin (RR)";

            readyProcesses = new List<Process>();
            sleepProcesses = new List<Process>();
            currentProcessIndex = -1;
            interval = 0;
        }



        //Запуск процессов
        public override void Start() {
            if (IsProcessing()) {
                return;
            }

            sleepProcesses.Clear();
            readyProcesses.Clear();
            sleepProcesses.AddRange(processes);

            interval = 0;
            currentProcessIndex = -1;
            base.Start();
        }

        //Возвращает ближайшее время запуска одного из процессов
        private int getNearestStartTime() {
            int minStartTime = int.MaxValue;
            for (int i = 0; i < sleepProcesses.Count; i++) {
                if (sleepProcesses[i].GetStartTime() < minStartTime) {
                    minStartTime = sleepProcesses[i].GetStartTime();
                }
            }

            return minStartTime;
        }

        //Запускает ожидание процесса
        private void waitForProcess() {
            logs.AppendLine((currentTime/1000.0) + ": -1");

            currentProcessIndex = -1;
            currentProcess = null;

            interval = getNearestStartTime() - currentTime;
            timer.Interval = getInterval(interval);
            currentTime += interval;
        }

        //Запускает выполнение следующего процесса
        private void nextProcess() {
            currentProcessIndex = (currentProcessIndex + 1) % readyProcesses.Count;
            currentProcess = readyProcesses[currentProcessIndex];
            currentProcess.SetActive(true);

            logs.AppendLine((currentTime/1000.0) + ": " + currentProcess.GetIndex());

            interval = Math.Min(100, currentProcess.GetRestDuration());
            timer.Interval = getInterval(interval);
            currentTime += interval;
        }

        //Останавливает выполнение
        private void stop() {
            timer.Stop();
            ended = true;
            currentProcess = null;
            if (onEnd != null) {
                onEnd.Invoke(this, null);
            }
        }

        //Событие тика таймера
        protected override void timer_Tick(object sender, EventArgs e) {
            if (sleepProcesses.Count == 0 && readyProcesses.Count == 0) {
                stop();
                view.Invalidate();
                return;
            }

            //Пополняем очередь
            for (int i = 0; i < sleepProcesses.Count; i++) {
                if (sleepProcesses[i].GetStartTime() <= currentTime) {
                    readyProcesses.Add(sleepProcesses[i]);
                    sleepProcesses.RemoveAt(i);
                    i--;
                }
            }

            //Если очереди нет, то ждем ближайший процесс
            if (readyProcesses.Count == 0) {
                waitForProcess();
                view.Invalidate();
                return;
            }

            //Обновляем данные процессов
            foreach (Process process in processes) {
                process.Update(currentTime);
            }

            //Если текущий процесс есть и он завершен
            if (currentProcessIndex > -1 && readyProcesses[currentProcessIndex].IsDone()) {
                //Удаляем процесс
                readyProcesses.RemoveAt(currentProcessIndex);
                doneProcessesCount++;

                if (readyProcesses.Count == 0) {
                    //Останавливаем, если процессов больше нет
                    if (sleepProcesses.Count == 0) {
                        stop();
                    } else {
                        waitForProcess();
                    }
                } else {
                    nextProcess();
                }
            } else {
                if (currentProcessIndex > -1) {
                    readyProcesses[currentProcessIndex].SetActive(false);
                }

                nextProcess();
            }

            view.Invalidate();
        }
    }
}
