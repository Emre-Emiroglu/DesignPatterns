namespace DesignPatterns.Runtime.Behavioral.TemplateMethod
{
    public abstract class Template<TContext>
    {
        #region Executes
        public void Execute(TContext context)
        {
            OnStart(context);

            Process(context);
            
            OnFinish(context);
        }
        protected virtual void OnStart(TContext context) { }
        protected virtual void Process(TContext context) { }
        protected virtual void OnFinish(TContext context) { }
        #endregion
    }
}