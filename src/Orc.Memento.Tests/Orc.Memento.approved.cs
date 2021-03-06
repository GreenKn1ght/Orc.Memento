﻿[assembly: System.Resources.NeutralResourcesLanguageAttribute("en-US")]
[assembly: System.Runtime.Versioning.TargetFrameworkAttribute(".NETFramework,Version=v4.6", FrameworkDisplayName=".NET Framework 4.6")]
public class static ModuleInitializer
{
    public static void Initialize() { }
}
namespace Orc.Memento
{
    public class ActionUndo : Orc.Memento.UndoBase
    {
        public ActionUndo(object target, System.Action undoAction, System.Action redoAction = null, object tag = null) { }
        protected override void RedoAction() { }
        protected override void UndoAction() { }
    }
    public class Batch : Catel.IUniqueIdentifyable, Orc.Memento.IMementoBatch
    {
        public Batch() { }
        public int ActionCount { get; }
        public System.Collections.Generic.IEnumerable<Orc.Memento.IMementoSupport> Actions { get; }
        public bool CanRedo { get; }
        public string Description { get; set; }
        public bool IsEmptyBatch { get; }
        public bool IsSingleActionBatch { get; }
        public string Title { get; set; }
        public int UniqueIdentifier { get; }
        public void AddAction(Orc.Memento.IMementoSupport action) { }
        public void ClearActionsForObject(object obj) { }
        public void Redo() { }
        public void Undo() { }
    }
    public enum CollectionChangeType
    {
        Add = 0,
        Remove = 1,
        Replace = 2,
        Move = 3,
    }
    public class CollectionChangeUndo : Orc.Memento.UndoBase
    {
        public CollectionChangeUndo(System.Collections.IList collection, Orc.Memento.CollectionChangeType type, int oldPosition, int newPosition, object oldValue, object newValue, object tag = null) { }
        public Orc.Memento.CollectionChangeType ChangeType { get; }
        public System.Collections.IList Collection { get; }
        public int NewPosition { get; }
        public object NewValue { get; }
        public object OldValue { get; }
        public int Position { get; }
        protected override void RedoAction() { }
        protected override void UndoAction() { }
    }
    public class CollectionObserver : Orc.Memento.ObserverBase
    {
        public CollectionObserver(System.Collections.Specialized.INotifyCollectionChanged collection, object tag = null, Orc.Memento.IMementoService mementoService = null) { }
        public override void CancelSubscription() { }
        public void OnCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) { }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Method | System.AttributeTargets.Property | System.AttributeTargets.All)]
    public sealed class IgnoreMementoSupportAttribute : System.Attribute
    {
        public IgnoreMementoSupportAttribute() { }
    }
    public interface IMementoBatch
    {
        int ActionCount { get; }
        System.Collections.Generic.IEnumerable<Orc.Memento.IMementoSupport> Actions { get; }
        bool CanRedo { get; }
        string Description { get; set; }
        bool IsEmptyBatch { get; }
        bool IsSingleActionBatch { get; }
        string Title { get; set; }
        void Redo();
        void Undo();
    }
    public interface IMementoService
    {
        bool CanRedo { get; }
        bool CanUndo { get; }
        bool IsEnabled { get; set; }
        int MaximumSupportedBatches { get; set; }
        System.Collections.Generic.IEnumerable<Orc.Memento.IMementoBatch> RedoBatches { get; }
        System.Collections.Generic.IEnumerable<Orc.Memento.IMementoBatch> UndoBatches { get; }
        public event System.EventHandler<Orc.Memento.MementoEventArgs> Updated;
        bool Add(Orc.Memento.IMementoSupport operation, bool noInsertIfExecutingOperation = True);
        bool Add(Orc.Memento.IMementoBatch batch, bool noInsertIfExecutingOperation = True);
        Orc.Memento.IMementoBatch BeginBatch(string title = null, string description = null);
        void Clear(object instance = null);
        Orc.Memento.IMementoBatch EndBatch();
        bool Redo();
        void RegisterCollection(System.Collections.Specialized.INotifyCollectionChanged collection, object tag = null);
        void RegisterObject(System.ComponentModel.INotifyPropertyChanged instance, object tag = null);
        bool Undo();
        void UnregisterCollection(System.Collections.Specialized.INotifyCollectionChanged collection);
        void UnregisterObject(System.ComponentModel.INotifyPropertyChanged instance);
    }
    public interface IMementoSupport
    {
        bool CanRedo { get; }
        string Description { get; set; }
        object Tag { get; set; }
        object Target { get; }
        void Redo();
        void Undo();
    }
    public enum MementoAction
    {
        Undo = 0,
        Redo = 1,
    }
    public class MementoEventArgs : System.EventArgs
    {
        public MementoEventArgs(Orc.Memento.MementoAction mementoAction) { }
        public Orc.Memento.MementoAction MementoAction { get; }
    }
    public class MementoService : Orc.Memento.IMementoService
    {
        public const int DefaultMaximumSupportedActions = 300;
        public MementoService() { }
        public MementoService(int maximumSupportedBatches) { }
        public bool CanRedo { get; }
        public bool CanUndo { get; }
        public static Orc.Memento.IMementoService Default { get; }
        public bool IsEnabled { get; set; }
        public int MaximumSupportedBatches { get; set; }
        public System.Collections.Generic.IEnumerable<Orc.Memento.IMementoBatch> RedoBatches { get; }
        public System.Collections.Generic.IEnumerable<Orc.Memento.IMementoBatch> UndoBatches { get; }
        public event System.EventHandler<Orc.Memento.MementoEventArgs> Updated;
        public bool Add(Orc.Memento.IMementoSupport operation, bool noInsertIfExecutingOperation = True) { }
        public bool Add(Orc.Memento.IMementoBatch batch, bool noInsertIfExecutingOperation = True) { }
        public Orc.Memento.IMementoBatch BeginBatch(string title = null, string description = null) { }
        public void Clear(object instance = null) { }
        public Orc.Memento.IMementoBatch EndBatch() { }
        public bool Redo() { }
        public void RegisterCollection(System.Collections.Specialized.INotifyCollectionChanged collection, object tag = null) { }
        public void RegisterObject(System.ComponentModel.INotifyPropertyChanged instance, object tag = null) { }
        public bool Undo() { }
        public void UnregisterCollection(System.Collections.Specialized.INotifyCollectionChanged collection) { }
        public void UnregisterObject(System.ComponentModel.INotifyPropertyChanged instance) { }
    }
    public class ObjectObserver : Orc.Memento.ObserverBase
    {
        public ObjectObserver(System.ComponentModel.INotifyPropertyChanged propertyChanged, object tag = null, Orc.Memento.IMementoService mementoService = null) { }
        public override void CancelSubscription() { }
        public void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) { }
    }
    public abstract class ObserverBase
    {
        protected ObserverBase(object tag, Orc.Memento.IMementoService mementoService = null) { }
        protected Orc.Memento.IMementoService MementoService { get; }
        public object Tag { get; set; }
        public abstract void CancelSubscription();
    }
    public class OperationSet : Orc.Memento.UndoBase
    {
        public OperationSet(object target, System.Collections.Generic.IEnumerable<Orc.Memento.IMementoSupport> operations = null, object tag = null) { }
        public void Add(Orc.Memento.IMementoSupport operation) { }
        public void AddRange(System.Collections.Generic.IEnumerable<Orc.Memento.IMementoSupport> operations) { }
        protected override void RedoAction() { }
        protected override void UndoAction() { }
    }
    public class PropertyChangeUndo : Orc.Memento.UndoBase
    {
        public PropertyChangeUndo(object target, string propertyName, object oldValue, object newValue = null, object tag = null) { }
        public object NewValue { get; }
        public object OldValue { get; }
        public string PropertyName { get; }
        protected override void RedoAction() { }
        protected override void UndoAction() { }
    }
    public abstract class UndoBase : Orc.Memento.IMementoSupport
    {
        protected UndoBase(object target, object tag) { }
        public bool CanRedo { get; set; }
        public string Description { get; set; }
        public object Tag { get; set; }
        public object Target { get; }
        public void Redo() { }
        protected abstract void RedoAction();
        public void Undo() { }
        protected abstract void UndoAction();
    }
}