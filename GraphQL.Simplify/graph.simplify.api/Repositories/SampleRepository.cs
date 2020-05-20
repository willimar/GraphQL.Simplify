using crud.api.core.enums;
using crud.api.core.interfaces;
using crud.api.core.repositories;
using graph.simplify.api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace graph.simplify.api.Repositories
{
    internal class HandleMessageAbs : IHandleMessage
    {
        public string MessageType { get; }

        public string Message { get; }

        public HandlesCode Code { get; }

        public List<string> StackTrace { get; }

        public HandleMessageAbs(string message, string type, HandlesCode code)
        {
            Message = message;
            MessageType = type;
            Code = code;
            StackTrace = new List<string>();
        }
    }

    public class SampleRepository : IRepository<Sample>
    {
        private readonly List<Sample> _samples = new List<Sample>();

        public SampleRepository()
        {
            _samples.Add(
                new Sample()
                {
                    BooleanProperty = true,
                    ByteProperty = new byte(),
                    CharProperty = 'a',
                    DateTimeProperty = DateTime.UtcNow,
                    DecimalProperty = 0.01M,
                    DoubleProperty = 30.002,
                    EnumeratorProperty = EnumeratorField.first,
                    FloatProperty = 1.003F,
                    IntProperty = 1,
                    LongProperty = 90001,
                    ShortProperty = 1,
                    StringProperty = "Dotes ver pedia longe sobre tirou todas fio com"
                });
            _samples.Add(
                new Sample()
                {
                    BooleanProperty = true,
                    ByteProperty = new byte(),
                    CharProperty = 'a',
                    DateTimeProperty = DateTime.UtcNow,
                    DecimalProperty = 0.01M,
                    DoubleProperty = 04.002,
                    EnumeratorProperty = EnumeratorField.first,
                    FloatProperty = 1.003F,
                    IntProperty = 1,
                    LongProperty = 9013001,
                    ShortProperty = 1,
                    StringProperty = "Aproximar continuou que instantes encontres dar"
                });
            _samples.Add(
                new Sample()
                {
                    BooleanProperty = true,
                    ByteProperty = new byte(),
                    CharProperty = 'a',
                    DateTimeProperty = DateTime.UtcNow,
                    DecimalProperty = 0.01M,
                    DoubleProperty = 05.002,
                    EnumeratorProperty = EnumeratorField.first,
                    FloatProperty = 1.003F,
                    IntProperty = 13,
                    LongProperty = 90001,
                    ShortProperty = 1,
                    StringProperty = "Torrentes se narcotico avigorada ou apertando em"
                });
            _samples.Add(
                new Sample()
                {
                    BooleanProperty = true,
                    ByteProperty = new byte(),
                    CharProperty = 'a',
                    DateTimeProperty = DateTime.UtcNow,
                    DecimalProperty = 0.01M,
                    DoubleProperty = 0.002,
                    EnumeratorProperty = EnumeratorField.first,
                    FloatProperty = 1.003F,
                    IntProperty = 31,
                    LongProperty = 90001,
                    ShortProperty = 1,
                    StringProperty = "Dor emfim nos andar cre accao sim beber terem"
                });
            _samples.Add(
                new Sample()
                {
                    BooleanProperty = true,
                    ByteProperty = new byte(),
                    CharProperty = 'a',
                    DateTimeProperty = DateTime.UtcNow,
                    DecimalProperty = 0.01M,
                    DoubleProperty = 0.002,
                    EnumeratorProperty = EnumeratorField.first,
                    FloatProperty = 1.003F,
                    IntProperty = 12,
                    LongProperty = 90001,
                    ShortProperty = 1,
                    StringProperty = "Vilissima espantado tal vivamente com nem"
                });
            _samples.Add(
                new Sample()
                {
                    BooleanProperty = true,
                    ByteProperty = new byte(),
                    CharProperty = 'a',
                    DateTimeProperty = DateTime.UtcNow,
                    DecimalProperty = 0.01M,
                    DoubleProperty = 0.002,
                    EnumeratorProperty = EnumeratorField.first,
                    FloatProperty = 1.003F,
                    IntProperty = 1,
                    LongProperty = 90001,
                    ShortProperty = 12,
                    StringProperty = "Apresento meu apunhalar ama seitornou sao novidades"
                });
            _samples.Add(
                new Sample()
                {
                    BooleanProperty = true,
                    ByteProperty = new byte(),
                    CharProperty = 'a',
                    DateTimeProperty = DateTime.UtcNow,
                    DecimalProperty = 0.01M,
                    DoubleProperty = 0.002,
                    EnumeratorProperty = EnumeratorField.first,
                    FloatProperty = 1.003F,
                    IntProperty = 1,
                    LongProperty = 90001,
                    ShortProperty = 31,
                    StringProperty = "Tao lhe dar tive veio auge tem"
                });
            _samples.Add(
                new Sample()
                {
                    BooleanProperty = true,
                    ByteProperty = new byte(),
                    CharProperty = 'a',
                    DateTimeProperty = DateTime.UtcNow,
                    DecimalProperty = 0.01M,
                    DoubleProperty = 0.002,
                    EnumeratorProperty = EnumeratorField.first,
                    FloatProperty = 1.003F,
                    IntProperty = 12,
                    LongProperty = 90001,
                    ShortProperty = 12,
                    StringProperty = "Ca simulando agradavel encarando os os casamento consultou vilissima"
                });
            _samples.Add(
                new Sample()
                {
                    BooleanProperty = true,
                    ByteProperty = new byte(),
                    CharProperty = 'a',
                    DateTimeProperty = DateTime.UtcNow,
                    DecimalProperty = 0.01M,
                    DoubleProperty = 0.002,
                    EnumeratorProperty = EnumeratorField.first,
                    FloatProperty = 1.003F,
                    IntProperty = 12,
                    LongProperty = 90001,
                    ShortProperty = 1,
                    StringProperty = "Helena senhor propor ah cravae notado sonhos eu."
                });
            _samples.Add(
                new Sample()
                {
                    BooleanProperty = true,
                    ByteProperty = new byte(),
                    CharProperty = 'a',
                    DateTimeProperty = DateTime.UtcNow,
                    DecimalProperty = 0.01M,
                    DoubleProperty = 0.002,
                    EnumeratorProperty = EnumeratorField.first,
                    FloatProperty = 1.003F,
                    IntProperty = 1,
                    LongProperty = 90001,
                    ShortProperty = 21,
                    StringProperty = "Ii soffridas realmente arranjado infernaes apparecer ti."
                });
        }

        public IEnumerable<IHandleMessage> AppenData(Sample entity)
        {
            this._samples.Add(entity);
            return new List<IHandleMessage>() { new HandleMessageAbs("Temporary inserted data.", "InsertDataSuccess", HandlesCode.Accepted) };
        }

        public IEnumerable<IHandleMessage> DeleteData(Sample entity)
        {
            this._samples.Remove(entity);
            return new List<IHandleMessage>() { new HandleMessageAbs("Deleted data.", "DeletedDataSuccess", HandlesCode.Accepted) };
        }

        public void Dispose()
        {
            _samples.Clear();
        }

        public IEnumerable<Sample> GetData(Expression<Func<Sample, bool>> func, int top = 0, int page = 0)
        {
            return _samples.ToList().Where(func.Compile());
        }

        public IEnumerable<IHandleMessage> UpdateData(Sample entity, Expression<Func<Sample, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
