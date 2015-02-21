using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS
{
    delegate void SubCollectionUpdatedDelegate(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e);
    /// <summary>
    /// Used for re-pulling competitors from the database whenever there is an update.
    /// </summary>
    delegate void UpdateCompetitorDelegate();

    /// <summary>
    /// Used whenever a forced update is required.
    /// </summary>
    delegate void UpdateAccuracyDataDelegate(Dictionary<EventCompetitor, List<Accuracy.AccuracyLanding>> eventData);
}
