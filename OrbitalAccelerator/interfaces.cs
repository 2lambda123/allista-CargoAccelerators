using AT_Utils;
using UnityEngine;

namespace CargoAccelerators
{
    public partial class OrbitalAccelerator
    {
        public float GetModuleMass(float defaultMass, ModifierStagingSituation sit)
        {
            return barrelSegments.Count * SegmentMass + (float)(ConstructedMass + trashMass);
        }

        public ModifierChangeWhen GetModuleMassChangeWhen() => ModifierChangeWhen.CONSTANTLY;

        public float GetModuleCost(float defaultCost, ModifierStagingSituation sit)
        {
            if(ConstructedMass > 0)
                return (barrelSegments.Count + (float)ConstructedMass / SegmentMass) * segmentCost;
            return barrelSegments.Count * segmentCost;
        }

        public ModifierChangeWhen GetModuleCostChangeWhen() => ModifierChangeWhen.CONSTANTLY;

        public Transform GetTransform()
        {
            if(loadingDamper != null && loadingDamper.attractor != null)
                return loadingDamper.attractor;
            return vessel.GetTransform();
        }

        public Vector3 GetObtVelocity() => vessel.GetObtVelocity();

        public Vector3 GetSrfVelocity() => vessel.GetSrfVelocity();

        public Vector3 GetFwdVector()
        {
            if(loadingDamper != null && loadingDamper.attractor != null)
                return loadingDamper.attractorAxisW;
            return vessel.GetFwdVector();
        }

        public Vessel GetVessel() => vessel;

        public string GetName() => part.Title();

        public string GetDisplayName() => GetName();

        public Orbit GetOrbit() => vessel.GetOrbit();

        public OrbitDriver GetOrbitDriver() => vessel.GetOrbitDriver();

        public VesselTargetModes GetTargetingMode() => VesselTargetModes.DirectionVelocityAndOrientation;

        public bool GetActiveTargetable() => false;
    }

    public class OrbitalAcceleratorUpdater : ModuleUpdater<OrbitalAccelerator>
    {
        protected override void on_rescale(ModulePair<OrbitalAccelerator> mp, Scale scale)
        {
            mp.module.SegmentMass = mp.base_module.SegmentMass * scale.absolute.volume;
            mp.module.ScaffoldDeployTime = mp.base_module.ScaffoldDeployTime * scale.absolute.volume;
            mp.module.UpdateParams();
            mp.module.UpdateSegmentCost();
        }
    }
}
