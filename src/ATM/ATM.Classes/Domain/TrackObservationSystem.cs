using System.Collections.Generic;
using System.Linq;
using ATM.Classes.Boundary;
using ATM.Classes.Interfaces;
using TransponderReceiver;

namespace ATM.Classes.Domain
{
    public class TrackObservationSystem
    {
        public ITransponderReceiver Receiver { get; set; }
        public ITrackFactory TrackFactory { get; set; }
        public ITrackRepository TrackRepository { get; set; }

        public TrackObservationSystem(ITransponderReceiver receiver, ITrackFactory trackFactory, ITrackRepository trackRepository)
        {
            TrackRepository = trackRepository;
            TrackFactory = trackFactory;
            Receiver = receiver;

            Receiver.TransponderDataReady += ReceiverOnTransponderDataReady;
        }

        private void ReceiverOnTransponderDataReady(object sender,
            RawTransponderDataEventArgs rawTransponderDataEventArgs)
        {
            var listOfTracks = new List<ITrack>();

            foreach (var track in rawTransponderDataEventArgs.TransponderData)
            {
                listOfTracks.Add(TrackFactory.GetTrack(track));
            }

            TrackRepository.Add(listOfTracks);


        }
    }


    //public class TrackObservationSystem : ITrackObservationSystem
    //{
    //    public ITransponderReceiver Receiver { get; set; }
    //    public ITrackRepository TrackRepository { get; set; } = new TrackRepository();
    //    public IOutput Output { get; set; } = new Output();
    //    public IAirSpace AirSpace { get; set; } = new AirSpace();
    //    public ISeperation Seperation { get;set; } = new Seperation();
    //    public ISeperationAlertRepository SeperationAlertRepository { get; set; } = new SeperationAlertRepository();

    //    public bool ConsoleOut { get; set; } = true;

    //    public TrackObservationSystem(ITransponderReceiver receiver)
    //    {
    //        Receiver = receiver;
    //        receiver.TransponderDataReady += ReceiverOnTransponderDataReady;
    //        Seperation.SeperationEvent += OnSeperation;
    //    }

    //    private void ReceiverOnTransponderDataReady(object sender, RawTransponderDataEventArgs rawTransponderDataEventArgs)
    //    {
    //        Update();

    //        foreach (var v in rawTransponderDataEventArgs.TransponderData)
    //        {
    //            TrackRepository.Add(v);
    //        }

    //        foreach (var t in TrackRepository.GetAll())
    //        {
    //            t.IsInAirspace = AirSpace.CheckAirSpace(t.Vector);
    //            Seperation.CheckSeperation(TrackRepository.GetAll().ToList(), t);
    //        }

    //        if (ConsoleOut)
    //        {
    //            Display();
    //        }
    //    }

    //    private void OnSeperation(object sender, SeperationEventArgs e)
    //    {
    //        if (!ConsoleOut) return;

    //        var seperationAlert = new SeperationAlert(e.Tag1, e.Tag2, e.Time);

    //        SeperationAlertRepository.Add(seperationAlert);
    //    }

    //    private void Display()
    //    {
    //        Output.Print(TrackRepository.GetAll());

    //        foreach (var seperationAlert in SeperationAlertRepository.GetAll())
    //        {
    //            Output.SeperationAlert(seperationAlert);
    //        }
    //    }

    //    private void Update()
    //    {
    //        var tracks = TrackRepository.GetAll().ToList();
    //        var seperationAlerts = SeperationAlertRepository.GetAll();

    //        var list = seperationAlerts.Select(alerts => tracks.FirstOrDefault(o => o.Tag == alerts.Tag1)).ToList();

    //        var toRemove = Seperation.CheckSeperation(list).ToList();

    //        if (!toRemove.Any()) return;

    //        foreach (var track in toRemove)
    //        {
    //            SeperationAlertRepository.Remove(track.Item1, track.Item2);
    //        }
    //    }
    //}
}
