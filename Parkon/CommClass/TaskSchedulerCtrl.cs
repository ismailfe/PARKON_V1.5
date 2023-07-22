using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskScheduler;


namespace Parkon
{
    public class TaskSchedulerCtrl
    {
        public CLS CLS;

        public void Start()
        {
            TaskScheduler.TaskScheduler scheduler = new TaskScheduler.TaskScheduler();
            scheduler.Connect();

            ITaskDefinition definition                  = scheduler.NewTask(0);
            definition.RegistrationInfo.Author          = "IDEMIR";
            definition.RegistrationInfo.Description     = "PARKON";
            definition.Principal.RunLevel               = _TASK_RUNLEVEL.TASK_RUNLEVEL_HIGHEST;
            definition.Settings.StartWhenAvailable      = true;

            definition.Triggers.Create(_TASK_TRIGGER_TYPE2.TASK_TRIGGER_LOGON);

            IExecAction action = (IExecAction)definition.Actions.Create(_TASK_ACTION_TYPE.TASK_ACTION_EXEC);

            action.Path = CLS.App_Path;

            scheduler.GetFolder("\\").RegisterTaskDefinition("Proje Arşivleme ve Kontrol Sistemi", definition, 6, Type.Missing, Type.Missing, TaskScheduler._TASK_LOGON_TYPE.TASK_LOGON_NONE);


        }

    }
}
