using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace os_lab2 {
    public class FCFS : ProcessManager {
        //Конструктор
        public FCFS(List<Process> processes, PictureBox view) : base(processes, view) {
            name = "First Come First Served (FCFS)";
        }



        //Устанавливает скорость выполнения
        public override void SetSpeed(int ms) {
            base.SetSpeed(ms);
            timer.Interval = speed;
        }

        //Возвращает текущий процесс
        private Process getCurrentProcess() {
            for (int i = 0; i < processes.Count; i++) {
                if (processes[i].GetStartTime() <= currentTime && !processes[i].IsDone()) {
                    return processes[i];
                }
            }

            return null;
        }

        //Событие тика таймера
        protected override void timer_Tick(object sender, EventArgs e) {                
            if (currentProcess == null) {
                currentProcess = getCurrentProcess();
            }

            if (currentProcess != null) {
                currentProcess.SetActive(true);
                logs.AppendLine((currentTime/1000.0) + ": " + currentProcess.GetIndex());
            } else {
                logs.AppendLine((currentTime/1000.0) + ": -1");
            }

            foreach (Process process in processes) {
                process.Update(currentTime);
            }

            if (currentProcess != null && currentProcess.IsDone()) {
                doneProcessesCount++;
                currentProcess = null;
            }

            if (doneProcessesCount >= processes.Count) {
                timer.Stop();
                ended = true;
                if (onEnd != null) {
                    onEnd.Invoke(this, null);
                }
            } else {
                currentTime += 1000;
            }

            view.Invalidate();
        }
    }
}
