using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Collections.Generic;
using Microsoft.ProjectOxford.Face.Contract;
using System.Linq;

namespace CsuBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        private static IEnumerable<Face> faces = new Face[0];

        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            
            var faceHelper = new FaceHelper();
            int faceNumber = -1;

            var file = activity.Attachments.FirstOrDefault();
            if (file != null)
            {
                faces = await faceHelper.GetFaces(file);
                await context.PostAsync("Людей на фото: " + faces.Count().ToString());
            }
            else if (int.TryParse(activity.Text, out faceNumber) && faceNumber != -1 && faceNumber < faces.Count())
            {
                var description = faceHelper.FaceDescription(faces.ToList()[faceNumber]);
                await context.PostAsync(description);
            }
            else
            {
                await context.PostAsync("Извени друг, но я не знаю такой команды :(");
            }

            context.Wait(MessageReceivedAsync);
        }
    }
}