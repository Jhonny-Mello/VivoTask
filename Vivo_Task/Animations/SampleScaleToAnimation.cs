using CommunityToolkit.Maui.Animations;

namespace Vivo_Task.Animations
{
    /*
     * a class SampleScaleToAnimation é utilizada para animar elementos em escala.
     */
    class SampleScaleToAnimation : BaseAnimation
    {
        public double Scale { get; set; }

        public override Task Animate(VisualElement view, CancellationToken token = default) => view.ScaleTo(Scale, Length, Easing);
    }
}
