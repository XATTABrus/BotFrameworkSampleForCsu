using Microsoft.Bot.Connector;
using Microsoft.ProjectOxford.Common.Contract;
using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CsuBot.Dialogs
{
    public class FaceHelper
    {
        private readonly IFaceServiceClient _faceapi;
        IEnumerable<FaceAttributeType> _faceAttributes;

        public FaceHelper()
        {
            var apiKey = "476e9d244bf64d41abc8339c54ec986e";
            var apiServer = "https://northeurope.api.cognitive.microsoft.com/face/v1.0";
            _faceapi = new FaceServiceClient(apiKey, apiServer);

            _faceAttributes = new FaceAttributeType[] {
                FaceAttributeType.Gender,
                FaceAttributeType.Age,
                FaceAttributeType.Smile,
                FaceAttributeType.Emotion,
                FaceAttributeType.Glasses,
                FaceAttributeType.Hair,
                FaceAttributeType.Makeup
            };
        }

        public async Task<IEnumerable<Face>> GetFaces(Attachment file)
        {
            try
            {
                var wc = new WebClient();
                using (Stream imageFileStream = wc.OpenRead(file.ContentUrl))
                {
                    return await _faceapi.DetectAsync(imageFileStream, returnFaceId: true, returnFaceLandmarks: false, returnFaceAttributes: _faceAttributes);
                }
            }
            catch (FaceAPIException f)
            {
                File.WriteAllText(@"D:\Разработка\ForBots\ErrorsFace.txt", f.ErrorMessage.ToString());
                return new Face[0];
            }
            catch (Exception e)
            {
                File.WriteAllText(@"D:\Разработка\ForBots\Errors.txt", e.Message);
                return new Face[0];
            }
        }

        public string FaceDescription(Face face)
        {
            StringBuilder sb = new StringBuilder();
            
            // Добавляем пол, возраст, и улыбку.
            sb.Append($"О чеовеке: ");
            sb.Append($"Пол - {face.FaceAttributes.Gender}, ");
            sb.Append($"Возраст - {face.FaceAttributes.Age}, ");

            //// Добавляем распознавание макияжа
            //sb.Append($"Макияж: ");
            //sb.Append($"Губы - {face.FaceAttributes.Makeup.LipMakeup}");
            //sb.Append($"Глаза - {face.FaceAttributes.Makeup.EyeMakeup}");

            //// Добавление эмоций. Отображаем все эмоции уровень которых более 10%.
            //sb.Append("Эмоции: ");
            //EmotionScores emotionScores = face.FaceAttributes.Emotion;
            //if (emotionScores.Anger >= 0.1f) sb.Append(String.Format("Злость - {0:F1}%, ", emotionScores.Anger * 100));
            //if (emotionScores.Contempt >= 0.1f) sb.Append(String.Format("Презрение - {0:F1}%, ", emotionScores.Contempt * 100));
            //if (emotionScores.Disgust >= 0.1f) sb.Append(String.Format("Отвращение - {0:F1}%, ", emotionScores.Disgust * 100));
            //if (emotionScores.Fear >= 0.1f) sb.Append(String.Format("Страх - {0:F1}%, ", emotionScores.Fear * 100));
            //if (emotionScores.Happiness >= 0.1f) sb.Append(String.Format("Счастье - {0:F1}%, ", emotionScores.Happiness * 100));
            //if (emotionScores.Neutral >= 0.1f) sb.Append(String.Format("Нейтральность - {0:F1}%, ", emotionScores.Neutral * 100));
            //if (emotionScores.Sadness >= 0.1f) sb.Append(String.Format("Печаль - {0:F1}%, ", emotionScores.Sadness * 100));
            //if (emotionScores.Surprise >= 0.1f) sb.Append(String.Format("Удивление - {0:F1}%, ", emotionScores.Surprise * 100));

            //// Добавим очки
            //sb.Append($"Очки - {face.FaceAttributes.Glasses} ");

            //// Добавим волосы
            //sb.Append("Волосы: ");

            //// Показываем насколько человек лысый 1%.
            //if (face.FaceAttributes.Hair.Bald >= 0.01f)
            //    sb.Append(String.Format("Лысый на {0:F1}% ", face.FaceAttributes.Hair.Bald * 100));

            //// Показываем все цвета волос показатель кототрых больше 10%.
            //var hairColors = face.FaceAttributes.Hair.HairColor;
            //foreach (HairColor hairColor in hairColors)
            //{
            //    if (hairColor.Confidence >= 0.1f)
            //    {
            //        sb.Append(hairColor.Color.ToString());
            //        sb.Append(String.Format(" {0:F1}% ", hairColor.Confidence * 100));
            //    }
            //}

            // Return the built string.
            return sb.ToString();
        }
    }
}